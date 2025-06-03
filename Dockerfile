FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY API.Aventureo/API.Aventureo.csproj API.Aventureo/

RUN dotnet restore API.Aventureo/API.Aventureo.csproj
COPY . .

RUN dotnet publish API.Aventureo/API.Aventureo.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .


EXPOSE 8080
ENTRYPOINT ["dotnet", "API.Aventureo.dll"]
