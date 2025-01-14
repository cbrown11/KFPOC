

# Extractor Data

We're going to extract our data from a dockerized SQL database running on your laptop. View the docker docs if you don't yet have docker installed. To launch a local SQL container, you just need to run (if you havent already):

```

```


# Loader Data

We're going to load our data into a dockerized PostgreSQL database running on your laptop. View the docker docs if you don't yet have docker installed. To launch a local PostgreSQL container, you just need to run (if you havent already):

```
docker run --name devdb -p 5432:5432 -e POSTGRES_USER=devuser -e POSTGRES_PASSWORD=devpassword -d postgres
```

