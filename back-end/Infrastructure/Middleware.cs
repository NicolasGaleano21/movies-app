using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Infrastructure
{
    // Middleware to handle exceptions globally
    public class ExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    response.StatusCode,
                    Message = "An internal server error occurred.",
                    Details = ex.Message,
                };

                var json = JsonSerializer.Serialize(errorResponse);
                await response.WriteAsync(json);
            }
        }
    }
}
