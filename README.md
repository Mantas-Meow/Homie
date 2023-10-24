# Homie

University project

How to setup the database:
1. Download sql express (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. Download ssms (https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
3. (Most likely nebutinas) Galimai yra tarpiniai steps, bet per ssms prisidedi server kaip sql express
4. Per vs eini i view -> sql server object explorer
5. Sql server object explorer window pasirenki add sql server
6. Isirasai server name arba pasirinkt local ir ten jis bus pateiktas
7. Per vs arba ssms pasirenki add database prie reikiamo server (as ji uzvadinau HomieDb)
8. Per vs gali per properties pasiziuret db connection string (tik reikes pakeist source -> server, Catalog -> database)
9. In Homie.Data sukurti file appsettings.json, ten ivest:
    {
  "ConnectionStrings": {
    "MainDatabaseConnection": "***irasyti***"
  }
}
