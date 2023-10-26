# Homie

University project

How to setup the database:
1. Download SQL Express 2022 (https://www.microsoft.com/en-us/sql-server/sql-server-downloads). Basic install
2. Download SSMS (https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
3. Connect to the SQLEXPRESS server in SSMS
4. In VS go to View > SQL Server Object Explorer. Add the local SQL Server
5. In SSMS or VS add a database to the local server and name it "HomieDb"
6. Find the DB connection string in VS by right-clicking the local DB server > properties > Connection string
7. In Homie.Data create appsettings.json file with the following:		
   {
      "ConnectionStrings": {
         "MainDatabaseConnection": "Connection string"
      }			
   }

Replace "Data Source" to "Server" and "Catalog" to "database" (if you don't have Catalog or database add this to connection string: "Database=HomieDb") inside Connection string


