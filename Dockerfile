FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Imagen base para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copiamos el csproj primero para aprovechar cach�
COPY ["carproject.API/carproject.API.csproj", "carproject.API/"]
COPY ["carproject.Domain/carproject.Domain.csproj", "carproject.Domain/"]
COPY ["carproject.Application/carproject.Application.csproj", "carproject.Application/"]
COPY ["carproject.Infraestructure/carproject.Infraestructure.csproj", "carproject.Infraestructure/"]

# Restauramos dependencias
RUN dotnet restore "carproject.API/carproject.API.csproj"

# Copiamos el resto del c�digo
COPY . .

# Compilamos en Release
WORKDIR "/src/carproject.API"
RUN dotnet build "carproject.API.csproj" -c Release -o /app/build

# Publicamos la app
RUN dotnet publish "carproject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "carproject.API.dll"]
