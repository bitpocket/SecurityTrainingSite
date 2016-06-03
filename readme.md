# Security Training Site

# DB connection

- In SQL Management Studio connect to the SQL server at:
```
(localdb)\MSSQLLocalDB
```
If instance needed to be changed, please also ammend connection string at:
```
\SecurityTrainingSite\src\SecurityTrainingSite\appsettings.json
```
```
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SecurityTraining"
```

- open and run the script on localdb MSSQL Server
```
SecurityTraining-CreateDataBase.sql
```

# Deploy on Azure
See /doc/How to deploy SecurityTrainingSite to azure.pdf
