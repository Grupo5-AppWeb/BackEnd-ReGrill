using ReGrill.API.Inventory.Application.Internal.CommandServices;
using ReGrill.API.Inventory.Application.Internal.QueryServices;
using ReGrill.API.Inventory.Domain.Repositories;
using ReGrill.API.Inventory.Domain.Services;
using ReGrill.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

using ReGrill.API.Shared.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using ReGrill.API.Profile.Application.Internal.CommandServices;
using ReGrill.API.Profile.Application.Internal.QueryServices;
using ReGrill.API.Profile.Domain.Repositories;
using ReGrill.API.Profile.Domain.Services;
using ReGrill.API.Profile.Infrastucture.Persistence.EFC.Repositories;
using ReGrill.API.Orders.Application.Internal.CommandServices;
using ReGrill.API.Orders.Application.Internal.QueryServices;
using ReGrill.API.Orders.Domain.Repositories;
using ReGrill.API.Orders.Domain.Services;
using ReGrill.API.Orders.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });

// Configure Dependency Injection

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAdminStockRepository, AdminStockRepository>();
builder.Services.AddScoped<IAdminStockCommandService, AdminStockCommandService>();
builder.Services.AddScoped<IAdminStockQueryService, AdminStockQueryService>();
//Colocar lo siguiente, usen como plantilla
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

// Orders Bounded Context Injection Configuration
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();