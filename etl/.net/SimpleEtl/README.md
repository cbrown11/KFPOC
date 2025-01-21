Follow the ReadMe.md in the parent folder to setup docker container for:

- Azure Sql
= PostgreSql


To run the service locally, you will .net 8 installed if you havent already (or can run in docker container)

```
 dotnet --info
````

To run the service, this will build and restore


```
 cd etl\.net\SimpleEtl
 dotnet run
````





# Target Table SQL
Will need to create 

```
CREATE TABLE public.Asset (
	Id int GENERATED ALWAYS AS IDENTITY NOT NULL,
	Name varchar NULL,
	"Type" varchar NULL,
	CONSTRAINT asset_pk PRIMARY KEY (id)
);

```

