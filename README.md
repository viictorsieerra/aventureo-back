# HACER MIGRACI�N A BASE DE DATOS
___

**CREAR MIGRACI�N PARA LA BASE DE DATOS**
`dotnet ef migrations add migrationName --project Infrastructure.Aventureo --startup-project API.Aventureo`

**ACTUALIZAR LA BASE DE DATOS POR UNA MIGRACI�N**
`dotnet ef database update --project Infrastructure.Aventureo --startup-project API.Aventureo`