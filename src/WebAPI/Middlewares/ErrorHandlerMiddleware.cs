using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }

        private static async Task HandleError(HttpContext context, Exception exception)
        {
            var response = GetResponse(context);
            var result = GetResult(exception, response);

            await response.WriteAsync(result);
        }

        private static HttpResponse GetResponse(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (ushort)HttpStatusCode.InternalServerError;
            return response;
        }

        private static string GetResult(Exception exception, HttpResponse response)
        {
            var errorResponse = new ErrorResponse(response.StatusCode, response.HttpContext.Request.Path, exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            return result;
        }

        public class ErrorResponse
        {
            public int HttpStatusCode { get; }
            public string Endpoint { get; }
            public string Message { get; }

            public ErrorResponse(int httpStatusCode, string endpoint, string message)
            {
                HttpStatusCode = httpStatusCode;
                Endpoint = endpoint;
                Message = message;
            }
        }
    }
}
