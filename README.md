# KFPOC
I have created this while waiting for Docker to be set up on my KF laptop. The repository is accessible to everyone, but to run any of the components, you'll need your own Docker containers for SQL and PostgreSQL.
As part of a proof of concept (POC) exploring Meltano (Singer.IO), I added several additional demos to showcase various possibilities:

## 1. GraphQL API Facade over the Extractor/Source (SQL)
This demo shows how simple it is to create a GraphQL API using Hot Chocolate. By defining your model and resolving it through a repository pattern, you can easily set up a GraphQL API. Although I didn't create a Docker container for this, it’s easy to run if you have .NET 8 installed—just navigate to the project folder and run dotnet run.
## 2. Simple ETL in .NET Using Hexagonal Architecture
This example demonstrates an ETL process using Hexagonal architecture (ports and adapters), which facilitates easy testing and swapping of infrastructure sources. It also uses Automapper for object transformation and Dapper for bulk insert and update operations with minimal code. A Docker container is available for this, though the current version has issues connecting to the database Docker containers. You can easily run it as a console application by navigating to the project folder and using dotnet run. There is Graphql Api, though this is just a mutation to kick of the transfer but this can be anything and doesnt need to be an Api per say.
## 3 .POC of Dagster
This proof of concept showcases Dagster but requires additional setup, including Rust and Visual Studio C++ installations.

## Extractor Data

We're going to extract our data from a dockerized Azure SQL Emulator database running on your laptop. To launch a local Azure SQL container, you just need to follow the video which can be done via VS code or Azure Data Studio. (though I'm sure you can via command)

https://www.youtube.com/watch?v=3XgepwpBJP8

Data Source=localhost; 
Database=ResearchExample; 
User ID=sa; 
PWD=1ceCream",


## Loader Data

We're going to load our data into a dockerized PostgreSQL database running on your laptop. View the docker docs if you don't yet have docker installed. To launch a local PostgreSQL container, you just need to run in the folder postgreSql:

```
docker-compose up -d
```


# Local issues

For dotnet run and python it seems that Windows Security (Defender) was blocking the executable.

Go to Windows Security -> Virus and Threat protection settings -> Exclusions and add your folder to the exclusion list. (for exampe I added my "c:\_git").

Now have no issues running and dont get access denied


# References

## Docker
- https://docs.docker.com/get-started/docker-concepts/running-containers/multi-container-applications/

## SQL Server in Docker
- https://www.youtube.com/watch?v=3XgepwpBJP8&ab_channel=MicrosoftAzure

## Facade POC (.net Graphql)
- https://chillicream.com/docs/hotchocolate/v13
- https://dev.to/techiesdiary/net-60-clean-architecture-using-repository-pattern-and-dapper-with-logging-and-unit-testing-1nd9
- https://code-maze.com/using-dapper-with-asp-net-core-web-api/
- https://medium.com/@nibasnazeem/integrating-graphql-with-net-and-mssql-5e360f2b8871 (Docker Example for .net ref Hot Chocolate as well)
  
## Meltano POC
- https://meltano.com/
- https://docs.meltano.com/getting-started/meltano-at-a-glance/
- https://www.youtube.com/watch?v=kcR-HtUvB5c&ab_channel=harness
