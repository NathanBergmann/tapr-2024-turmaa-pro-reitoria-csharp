## Commands

```
docker run \
    --publish 8081:8081 \
    --publish 10250-10255:10250-10255 \
    --name cosmosdb-linux-emulator \
    --detach \
    mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest    

curl --insecure https://localhost:8081/_explorer/emulator.pem > ~/emulatorcert.crt

sudo cp ~/emulatorcert.crt /usr/local/share/ca-certificates/

sudo update-ca-certificates
```
#### Vá no Azure DataBase > Workspace > Attach DataBase Account > SQL > Copy this 
```
AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;
```

### Desligar ambiente docker do CODESPACE
```
docker stop cosmosdb-linux-emulator

docker stop _container_id
```
### Ligar ambiente o Docker
```
docker start _name_
```

### Desativar na UserSettings
```
http.proxyStrictSSL
```

### Mudar no appsettings.Development.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "CosmosDBURL":"AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;",
  "CosmosDBDBName":"dbcolegio"
}

### Sempre rodar para o azure
```curl --insecure https://localhost:8081/_explorer/emulator.pem > ~/emulatorcert.crt```
```sudo cp ~/emulatorcert.crt /usr/local/share/ca-certificates/```
```sudo update-ca-certificates```		

```keytool -importcert -file ~/emulatorcert.crt -keystore native.jks -alias cosmosdb```