Follow the ReadMe.md in the parent folder to setup docker container for:

- Azure Sql

To run the service locally, you will .net 8 installed if you havent already (or can run in docker container)

```
 dotnet --info
````

To run the service, this will build and restore


```
 cd facade\researchApi
 dotnet run
````



# Docker 

https://code.visualstudio.com/docs/containers/quickstart-aspnet-core

```
docker run --rm -it -v ${pwd}:/researchApi/ -w /researchApi mcr.microsoft.com/dotnet/sdk:8.0 dotnet run


```
