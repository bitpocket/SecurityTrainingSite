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
1. Create DataBase named 'securitytraining'
2. Install MS Management Studio and connect to: securitytraining.database.windows.net
3. Run a 'SecurityTraining-Create Tables-Azure.sql' script
5. Deploy 'SecurityTrainingSite' Solution from GitHub
5. Add connectionString under Azure Web App Configure as DefaultConnection=Server=tcp:securitytraining.database.windows.net,1433;Database=SecurityTraining;User ID=DogCatFrog@securitytraining;Password={your_password_here};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;
