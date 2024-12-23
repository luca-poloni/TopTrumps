using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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
                c.OperationFilter<AuthenticationOperationFilter>();
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

        public class AuthenticationOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (context.ApiDescription.RelativePath != null && context.ApiDescription.RelativePath.StartsWith("auth"))
                {
                    operation.Tags.Clear();
                    operation.Tags.Add(new OpenApiTag { Name = "Authentications" }); 
                }
            }
        }
    }
}
