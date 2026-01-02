# =========================
# ETAPA 1: BUILD
# =========================
# Usamos la imagen oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Directorio de trabajo dentro del contenedor
WORKDIR /src

# Copiamos el archivo del proyecto y restauramos dependencias
COPY ApiPersonas.csproj .
RUN dotnet restore

# Copiamos el resto del código fuente
COPY . .

# Compilamos y publicamos la aplicación en modo Release
RUN dotnet publish -c Release -o /app/publish


# =========================
# ETAPA 2: RUNTIME
# =========================
# Imagen ligera solo con el runtime (producción)
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Directorio de trabajo final
WORKDIR /app

# Copiamos solo los artefactos publicados desde la etapa build
COPY --from=build /app/publish .

# Puerto interno que expone la aplicación
EXPOSE 8080

# Variable de entorno recomendada para ASP.NET Core
ENV ASPNETCORE_URLS=http://+:8080

# Comando de inicio del contenedor
ENTRYPOINT ["dotnet", "ApiPersonas.dll"]
