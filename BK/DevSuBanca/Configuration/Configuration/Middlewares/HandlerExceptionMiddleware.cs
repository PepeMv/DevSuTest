using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Configuracion
{
    public class HandlerExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HandlerExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var errorNotificar =
                    new ProblemDetails((int)HttpStatusCode.InternalServerError,
                                       "Error en el servidor",
                                       ex.Message,
                                       $"{ex.InnerException?.Message} {ex.InnerException?.InnerException?.Message} {ex.InnerException?.InnerException?.InnerException?.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var json = JsonSerializer.Serialize(errorNotificar);
                await httpContext.Response.WriteAsync(json);

            }
        }

        public class ProblemDetails
        {
            public ProblemDetails(int status, string type, string title, string detail)
            {
                Status = status;
                Type = type;
                Title = title;
                Detail = detail;
            }

            public int Status { get; set; }
            public string Type { get; set; }
            public string Title { get; set; }
            public string Detail { get; set; }
        }
    }
}
