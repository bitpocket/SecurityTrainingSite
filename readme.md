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

- open and run the script
```
SecurityTraining-CreateDataBase.sql
```

# Deploy on server
1. Install MSSQL Server 2012 if not exists.
2. Install MS Management Studio
3. Create database from script
4. Deploy Solution
5. Setup connection string
6. Configure IIS