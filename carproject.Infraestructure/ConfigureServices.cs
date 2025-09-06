using carproject.Domain.Repositories;
using carproject.Infraestructure.Contexts;
using carproject.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace carproject.Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection string via appsettings or environment variable (Docker Compose sets ConnectionStrings__Default)
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<IMarcasAutosRepository, MarcasAutosRepository>();

            return services;
        }
    }
}
