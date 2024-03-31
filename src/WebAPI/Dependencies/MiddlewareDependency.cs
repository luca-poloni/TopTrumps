using WebAPI.Middlewares;

namespace WebAPI.Dependencies
{
    public static class MiddlewareDependency
    {
        public static WebApplication UseMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            return app;
        }
    }
}
