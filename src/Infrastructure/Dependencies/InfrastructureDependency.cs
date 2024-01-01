using Application.Common.Interfaces;
using Domain.Repositores;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string '{connectionStringName}' not found.");

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((sp, options) =>
            {
                options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ICardPlayerRepository, CardPlayerRepository>();
            services.AddTransient<IRoundRepository, RoundRepository>();

            return services;
        }
    }
}
