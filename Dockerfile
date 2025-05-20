# Usa la imagen base de .NET SDK para la construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["Aventureo-Back.sln", "./"]
COPY ["API.Aventureo/API.Aventureo.csproj", "API.Aventureo/"]
COPY ["Application.Aventureo/Application.Aventureo.csproj", "Application.Aventureo/"]
COPY ["Core.Aventureo/Core.Aventureo.csproj", "Core.Aventureo/"]
COPY ["Infraestructure.Aventureo/Infraestructure.Aventureo.csproj", "Infraestructure.Aventureo/"]

RUN dotnet restore
COPY . .

RUN dotnet publish "API.Aventureo/API.Aventureo.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .


EXPOSE 8080
ENTRYPOINT ["dotnet", "API.Aventureo.dll"]
