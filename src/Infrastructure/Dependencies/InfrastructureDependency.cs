using Ardalis.SharedKernel;
using Infrastructure.Context;
using Infrastructure.Identity;
using Infrastructure.Interceptors;
using Infrastructure.Repositories;
using Infrastructure.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);
            services.AddIdentity();
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException($"Connection string '{connectionStringName}' not found.");

            services.AddSingleton(TimeProvider.System);

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, AuditableDateEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
                options.UseSqlServer(connectionString)
                    .AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>()));

            return services;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<ApplicationUserIdentity>()
                .AddRoles<ApplicationRoleIdentity>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ApplicationRepository<>));

            return services;
        }

        public static WebApplication MapApplicationIdentity(this WebApplication app)
        {
            app.MapGroup("/auth")
                .MapIdentityApi<ApplicationUserIdentity>();

            return app;
        }
    }
}
