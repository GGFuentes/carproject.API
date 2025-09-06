using carproject.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace carproject.API.Modules.GlobalException
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // sigue con la petición
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message = ex.Message;

            switch (ex)
            {
                case ValidationException:
                case DomainException:
                    statusCode = HttpStatusCode.BadRequest; // 400
                    break;

                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound; // 404
                    break;

                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized; // 401
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError; // 500
                    message = "Se produjo un error interno en el servidor.";
                    break;
            }

            _logger.LogError(ex, "Error capturado en middleware");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Error = message
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
