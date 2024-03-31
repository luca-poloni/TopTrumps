using Application.Common.Dependencies;
using Infrastructure.Dependencies;
using WebAPI.Dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();

var app = builder.Build();

app.UseSwaggerWebApplication();
app.UseHttpsRedirection();
app.UseMiddlewares();
app.MapControllers();
app.Run();

public partial class Program { }