using Microsoft.OpenApi.Models;
using WebAPI.Middlewares;

namespace WebAPI.Dependencies
{
    public static class SwaggerDependency
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopTrumps", Version = "v1" });
                c.EnableAnnotations();
            });

            return services;
        }

        public static WebApplication UseSwaggerWebApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Top Trumps API V1"));
            }

            return app;
        }
    }
}
