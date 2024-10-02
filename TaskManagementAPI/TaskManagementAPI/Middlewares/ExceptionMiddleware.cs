using System.Net;
using System.Text.Json;

namespace TaskManagementAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);  //Continue with next middleware
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // set the ContentType and the StatusCode
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Crea una respuesta de error personalizada
            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = "An error occurred in the server."
            }.ToString());
        }

    }
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }


    //public class ExceptionMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly ILogger<ExceptionMiddleware> _logger;

    //    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    //    {
    //        _next = next;
    //        _logger = logger;
    //    }

    //    public async Task InvokeAsync(HttpContext httpContext)
    //    {
    //        try
    //        {
    //            await _next(httpContext); // Continua con el siguiente middleware
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError($"Ocurrió una excepción: {ex.Message}");
    //            await HandleExceptionAsync(httpContext, ex);
    //        }
    //    }

    //    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    //    {
    //        // Configura el tipo de contenido y el código de estado
    //        context.Response.ContentType = "application/json";
    //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    //        // Crea una respuesta de error personalizada
    //        var response = new ErrorDetails
    //        {
    //            StatusCode = context.Response.StatusCode,
    //            Message = "Se produjo un error en el servidor. Por favor, inténtalo de nuevo más tarde."
    //        };

    //        // Puedes agregar detalles adicionales en desarrollo
    //        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    //        if (environment == "Development")
    //        {
    //            response.Details = exception.StackTrace;
    //        }

    //        // Escribe la respuesta
    //        var jsonResponse = JsonSerializer.Serialize(response);
    //        return context.Response.WriteAsync(jsonResponse);
    //    }
    //}

    //// Clase para la estructura de la respuesta de error
    //public class ErrorDetails
    //{
    //    public int StatusCode { get; set; }
    //    public string Message { get; set; }
    //    public string Details { get; set; } // Opcional, para detalles adicionales en desarrollo
    //}
}
