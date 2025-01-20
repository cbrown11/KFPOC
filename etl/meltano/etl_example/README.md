

# Extractor Data

We're going to extract our data from a dockerized Azure SQL Emulator database running on your laptop. To launch a local Azure SQL container, you just need to follow the video which can be done via VS code or Azure Data Studio. (though I'm sure you can via command)

https://www.youtube.com/watch?v=3XgepwpBJP8

Data Source=localhost; 
Database=ResearchExample; 
User ID=sa; 
PWD=######,


# Loader Data

We're going to load our data into a dockerized PostgreSQL database running on your laptop. View the docker docs if you don't yet have docker installed. To launch a local PostgreSQL container, you just need to run (if you havent already):

The docker-compose.yml by going to the folder postgreSql and running
```
docker-compose up -d
```


# Transform

To run the EL only

```
meltano install
meltano run --full-refresh tap-mssql target-postgres
```


To run the ELT 

```
meltano install

# Invoke
meltano invoke dbt-postgres:run

# or Run (this seems better as will do an uppdate on second run)
meltano run tap-mssql target-postgres dbt-postgres:run

```

