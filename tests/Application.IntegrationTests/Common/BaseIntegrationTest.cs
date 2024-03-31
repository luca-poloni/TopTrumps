using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;

namespace Application.IntegrationTests.Common
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
    {
        private readonly string _connectionString;
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly ApplicationDbContext DbContext;

        private Respawner _respawner = default!;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _connectionString = factory.GetConnectionString();
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider
                .GetRequiredService<ISender>();

            DbContext = _scope.ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            DbContext.Database.Migrate();
        }

        public async Task InitializeAsync()
        {
            _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
            {
                TablesToIgnore = ["__EFMigrationsHistory"]
            });
        }

        public Task DisposeAsync()
        {
            return _respawner.ResetAsync(_connectionString);
        }
    }
}
