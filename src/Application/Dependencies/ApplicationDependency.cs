using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Dependencies
{
    public static class ApplicationDependency
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandler();
            return services;
        }

        private static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
