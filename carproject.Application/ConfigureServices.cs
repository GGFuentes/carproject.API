using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using carproject.Application.Interfaces;

namespace carproject.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddScoped<IMarcasAutosService, MarcasAutosService>();
            return services;
        }
    }
}
