using Application.Common.Interfaces;
using Domain.Constants;
using Domain.Core.Card;
using Domain.Core.Game;
using Infrastructure.Context;
using Infrastructure.Identity;
using Infrastructure.Interceptors;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
            services.AddUnitOfWork();

            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException($"Connection string '{connectionStringName}' not found.");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) => 
                options.UseSqlServer(connectionString)
                    .AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>()));

            return services;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton(TimeProvider.System);
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthorization(options =>
                options.AddPolicy(Policies.CanPurge, policy =>
                    policy.RequireRole(Roles.Administrator)));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IGameRepository, GameRepository>();

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
