using carproject.API.Modules.GlobalException;

namespace carproject.API.Modules.Middleware
{
    public static class MiddlewareExtensions
    {       
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
