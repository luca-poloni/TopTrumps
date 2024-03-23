using Application.Common.Interfaces;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Testcontainers.MsSql;

namespace Application.IntegrationTests.Core
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithAutoRemove(true)
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services
                    .RemoveAll<IUser>()
                    .AddTransient(provider => Mock.Of<IUser>(s => s.Id == "Tester"));

                services
                    .RemoveAll<DbContextOptions<ApplicationDbContext>>()
                    .AddDbContext<ApplicationDbContext>((sp, options) => 
                        options.UseSqlServer(_dbContainer.GetConnectionString())
                            .AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>()));
            });
        }

        public string GetConnectionString()
        {
            return _dbContainer.GetConnectionString();
        }

        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}
