using Asp.Versioning;
using InnovaSystem.Core.Application;
using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Infrastructure.Persistence;
using InnovaSystem.Infrastructure.Shared;
using InnovaSystem.WebApi.Extensions;
using InnovaSystem.WebApi.Middlewares;
using InnovaSystem.WebApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API",
        Version = "v1"
    });
});

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Inyección de servicios capa Web Api
//builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRequestContextAccessor, RequestContextAccessor>();

// Métodos de extension de servicios (custom)
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructurePersistenceServices(builder.Configuration); // Se debe ocupar el configureServices de Infrastructure Persistence
builder.Services.AddInfrastructureSharedServices(builder.Configuration); // Se debe ocupar el configureServices de Infrastructure Shared
builder.Services.ConfigureIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestContextMiddleware>();

app.MapControllers();

app.Run();
