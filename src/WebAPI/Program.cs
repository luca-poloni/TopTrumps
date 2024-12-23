using Application.Dependencies;
using Infrastructure.Dependencies;
using WebAPI.Dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSwaggerServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwaggerWebApplication();
app.UseHttpsRedirection();
app.UseMiddlewares();
app.MapControllers();
app.MapApplicationIdentity();
app.Run();

public partial class Program { }