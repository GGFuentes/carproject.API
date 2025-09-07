# carproject.API

API construida con **.NET 8** usando una arquitectura **DDD (Domain-Driven Design)** y respaldada por **PostgreSQL**.

##  Estructura del repositorio

- **carproject.API** – Proyecto principal (capa de presentación/API).
- **carproject.Application** – Lógica de aplicación y casos de uso.
- **carproject.Domain** – Entidades del negocio, agregados, interfaces (repositorios, etc.).
- **carproject.Infrastructure** – Implementaciones concretas (acceso a datos con EF Core, PostgreSQL, etc.).
- **carproject.CrossCutting** – Servicios transversales (mapeo, configuración, IoC, logging).
- **carproject.Tests** – Pruebas unitarias e integración.

##  Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com)
- [Docker](https://www.docker.com/) y [Docker Compose](https://docs.docker.com/compose/)
- (Opcional) Cliente PostgreSQL como `psql` o pgAdmin para acceso externo.

##  Levantar el entorno

1. Clona el repo:
   ```bash
   git clone https://github.com/GGFuentes/carproject.API.git
   cd carproject.API
   ```

2. Asegura que el `docker-compose.yml` esté configurado así:

   ```yaml
   services:
     api:
       build:
         context: .
         dockerfile: Dockerfile
       ports:
         - "5000:8080"
       environment:
         ASPNETCORE_ENVIRONMENT: Development
         ConnectionStrings__Default: "Host=db;Database=autobrands;Username=postgres;Password=123456"
       depends_on:
         - db

     db:
       image: postgres:15
       environment:
         POSTGRES_USER: postgres
         POSTGRES_PASSWORD: "123456"
         POSTGRES_DB: autobrands
       ports:
         - "5433:5432"
       volumes:
         - postgres_data:/var/lib/postgresql/data

   volumes:
     postgres_data:
   ```

3. Ejecuta:
   ```bash
   docker-compose down -v
   docker-compose up --build
   ```

4. Accede a tu API en `http://localhost:5000`.

   > ℹ Si usas otro puerto, ajústalo según la configuración.

##  Configuración

- **Cadena de conexión (appsettings.Development.json)**:
  
  ```jsonc
  {
    "ConnectionStrings": {
      "Default": "Host=db;Database=autobrands;Username=postgres;Password=123456"
    }
  }
  ```
  
- **Inyección de dependencias** (en `Program.cs`):
  - Registra `DbContext` con PostgreSQL.
  - Registra repositorios e interfaces.
  - Configura AutoMapper y otros servicios compartidos.

##  Migraciones y base de datos

Aplicación de ejemplo con EF Core:

```bash
cd carproject.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```

(O del lado del contenedor:)

```bash
docker exec -it carproject_api dotnet ef database update --project carproject.API
```

##  Testing

Para correr pruebas:

```bash
cd carproject.Tests
dotnet test
```

##  Buenas prácticas

- Respeta la separación de capas (Domain no debe depender de Infrastructure, etc.).
- Usa casos de uso claros en `Application`.
- Aplica inyección de dependencias desde `CrossCutting`.
- Escribe pruebas unitarias y de integración para servicios y lógica del dominio.

##  Contribuciones y mantenimiento

- Usa ramas feature/bugfix.
- Abre PRs con descripción clara.
- Añade tests para cualquier nueva lógica de negocio.

