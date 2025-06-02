# HACER MIGRACIÓN A BASE DE DATOS
___

**CREAR MIGRACIÓN PARA LA BASE DE DATOS**
`dotnet ef migrations add migrationName --project Infrastructure.Aventureo --startup-project API.Aventureo`

**ACTUALIZAR LA BASE DE DATOS POR UNA MIGRACIÓN**
`dotnet ef database update --project Infrastructure.Aventureo --startup-project API.Aventureo`