# Etapa 1: Build con el SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos la solución completa
COPY . .

# Restauramos dependencias (lo hace sobre la solución completa)
RUN dotnet restore "carproject.API/carproject.API.csproj"

# Compilamos el proyecto en Release
RUN dotnet build "carproject.API/carproject.API.csproj" -c Release -o /app/build

# Publicamos
RUN dotnet publish "carproject.API/carproject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Imagen ligera con solo runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "carproject.API.dll"]
