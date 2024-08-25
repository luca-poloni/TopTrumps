using Domain.Common.Primitives;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }

        private static async Task HandleError(HttpContext context, Exception exception)
        {
            var response = GetResponse(context, exception);
            var result = GetResult(response, exception);

            await response.WriteAsync(result);
        }

        private static HttpResponse GetResponse(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = GetStatusCode(exception);
            return response;
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                DomainBaseException => (int)HttpStatusCode.BadRequest,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };
        }

        private static string GetResult(HttpResponse response, Exception exception)
        {
            var errorResponse = new ErrorResponse(response.StatusCode, response.HttpContext.Request.Path, exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            return result;
        }

        public class ErrorResponse(int httpStatusCode, string endpoint, string message)
        {
            public int HttpStatusCode { get; } = httpStatusCode;
            public string Endpoint { get; } = endpoint;
            public string Message { get; } = message;
        }
    }
}
