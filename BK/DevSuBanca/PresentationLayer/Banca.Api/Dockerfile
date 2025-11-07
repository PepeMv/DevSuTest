# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo el resultado del publish
COPY ./publish ./ 
# Nota: ./publish es la carpeta que generas con `dotnet publish -c Release -o ./publish`

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8081
ENTRYPOINT ["dotnet", "Banca.Api.dll"]
