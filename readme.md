# Security Training Site

# DB conection

- In SQL Management Studio connect to the SQL server at:
```
(localdb)\MSSQLLocalDB
```
If instance needed to be changed, please also ammend connection string at:
```
\SecurityTrainingSite\src\DataAccessLayer\SQLHelper.cs
```
```
ConnectionString = "Server = (localdb)\\mssqllocaldb;Database=SecurityTraining";
```

- open and run the script
```
SecurityTraining-CreateDataBase.sql
```
