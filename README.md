# How to run the WebAPI and SQL server together with docker-compose

1. First go in to the AdvertisingSystem folder
```bash
cd AdvertisingSystem
```
2. Create a `.my-env file` with the following structure, where you can add the SA password for the database.
```
SA_PASSWORD="<Your_password>"
```
3. Run the following command
```bash
docker-compose --env-file .my-env up -d
```
4. After this, you can manage the containers with docker.
