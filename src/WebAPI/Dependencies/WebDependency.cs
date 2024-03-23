using Application.Common.Interfaces;
using WebAPI.Services;

namespace WebAPI.Dependencies
{
    public static class WebDependency
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddUser();

            return services;
        }

        private static IServiceCollection AddUser(this IServiceCollection services)
        {
            services.AddScoped<IUser, CurrentUser>();

            return services;
        }
    }
}
