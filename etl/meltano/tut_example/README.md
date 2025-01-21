
# Setup 

The following is worth a read and watch. It's important to note that Transform has been replaced with utilities (see Part 3 for details).

https://docs.meltano.com/getting-started/meltano-at-a-glance

I also found that this was worth a watch describing the Singer.Io schema

https://www.youtube.com/watch?v=kcR-HtUvB5c&ab_channel=harness

## Installation 

Followed the following steps 
- https://docs.meltano.com/getting-started/installation


require C++ tools for some package

- https://www.youtube.com/watch?v=x6OBMfLTLhA
- https://learn.microsoft.com/en-us/windows/package-manager/winget/#install-winget


```
winget install Microsoft.VisualStudio.2022.BuildTools --force --override "--passive -wait --add Microsoft.VisualStudio.VCTools;includedRecommended"
```

## Part 1 - Connect

Followed the following steps but used a tap-csv Loader instead tap-github
- https://docs.meltano.com/getting-started/part1

I added a customers.csv to data folder


## Part 2 - Store Data

Followed the following steps
- https://docs.meltano.com/getting-started/part2

In step two I used a different data connection data:

      host: localhost
      port: 5432
      user: devuser
      password: devpassword
      database: devdb


We're going to load our data into a dockerized PostgreSQL database running on your laptop. View the docker docs if you don't yet have docker installed. To launch a local PostgreSQL container, you just need to run (if you havent already):


The docker-compose.yml by going to the folder postgreSql and running
```
docker-compose up -d
```

Or run the command

```
docker run --name devdb -p 5432:5432 -e POSTGRES_USER=devuser -e POSTGRES_PASSWORD=devpassword -d postgres
```

The other difference is I called arget-postgres without variant, as seem the default now not 'wise'

```
meltano add loader target-postgres
```

## Part 3 - Process data

Followed the following steps but replaced tap_csv instead of tap-github
- https://docs.meltano.com/getting-started/part3

I created a customer.sql instead of author.sql
```
{{
  config(
    materialized='table'
  )
}}

with base as (
    select *
    from {{ source('tap_csv', 'raw_customers') }}
)
select *
from base
```

I had to removed 'target-path' and 'clean-targets' from dbt_project.yml as these seem to be depracated.

Updated dbt_project.yml to:

```
name: my_meltano_project
version: '1.0'
profile: meltano
config-version: 2
require-dbt-version: [">=1.0.0", "<2.0.0"]
flags:
  send_anonymous_usage_stats: False
  use_colors: True
model-paths:
- models
analysis-paths:
- analysis
test-paths:
- tests
seed-paths:
- data
macro-paths:
- macros
snapshot-paths:
- snapshots
log-path: logs
packages-install-path: dbt_packages
- dbt_packages
- logs
models:
  my_meltano_project: null

```

To create the actual table, we run the dbt model via meltano invoke dbt-postgres:run. Note this relies on previously running meltano

```
meltano run --full-refresh tap-csv target-postgres
```

## Run the transformation process


```
meltano lock --update --all
meltano invoke dbt-postgres:run
```


# Local issues

For dotnet run and python it seems that Windows Security (Defender) was blocking the executable.

Go to Windows Security -> Virus and Threat protection settings -> Exclusions and add your folder to the exclusion list. (for exampe I added my "c:\_git").

Now have no issues running and dont get access denied


# Docker

https://docs.meltano.com/guide/containerization/
https://medium.com/data-manypets/how-to-run-meltano-in-a-container-on-google-cloud-composer-860783d0575c

```
# Docker has been installed
docker --version

# Add Docker files to your project
meltano add files files-docker

# Build Docker image containing
# Meltano, your project, and all of its plugins
docker build --tag meltano-tut_example .
```

```
# View Meltano version
docker run meltano-tut_example --version

# simple run
docker run meltano-tut_example run tap-csv target-jsonl


# mounted  to exfiltrate target-jsonl output
docker run --mount type=bind,src=$(pwd)/output,dst=/project/output meltano-tut_example run tap-csv target-jsonl


# run the transformation process
docker run meltano-tut_example invoke dbt-postgres:run


# Debug by launching a shell on the container
docker run meltano-tut_example invoke dbt-postgres:run 



```