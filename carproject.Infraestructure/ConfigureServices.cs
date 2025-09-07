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
            var connectionString = configuration.GetConnectionString("Default")?? Environment.GetEnvironmentVariable("ConnectionStrings__Default");

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddScoped<IMarcasAutosRepository, MarcasAutosRepository>();

            return services;
        }
    }
}
