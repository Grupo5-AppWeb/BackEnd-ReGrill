using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReGrill.API.IAM.Application.Internal.CommandServices.Credential;
using ReGrill.API.IAM.Application.Internal.CommandServices.Roles;
using ReGrill.API.IAM.Application.Internal.CommandServices.Users;
using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Application.Internal.QueryServices.Credential;
using ReGrill.API.IAM.Application.Internal.QueryServices.Roles;
using ReGrill.API.IAM.Application.Internal.QueryServices.Users;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Repositories.Roles;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.IAM.Domain.Services.Roles;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;
using ReGrill.API.IAM.Domain.Services.Users.Administration;
using ReGrill.API.IAM.Domain.Services.Users.Supply;
using ReGrill.API.IAM.Infrastructure.Hashing.Argon2ld.Services;
using ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;
using ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;
using ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;
using ReGrill.API.IAM.Infrastructure.Poblation.Roles;
using ReGrill.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using ReGrill.API.IAM.Infrastructure.Tokens.JWT.Services;
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
using ReGrill.API.Recipes.Application.Internal.CommandServices;
using ReGrill.API.Recipes.Application.Internal.QueryServices;
using ReGrill.API.Recipes.Domain.Repositories;
using ReGrill.API.Recipes.Domain.Services;
using ReGrill.API.Recipes.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Sweet Manager API",
                Version = "v1",
                Description = "Sweet Manager API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Sweet Manager Studios",
                    Email = "contact@swm.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    } 
                }, 
                Array.Empty<string>()
            }
        });
    });

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

// IAM Bounded Context Injection Configuration
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeCommandService, RecipeCommandService>();
builder.Services.AddScoped<IRecipeQueryService, RecipeQueryService>();

//builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
builder.Services.AddScoped<IHashingService, HashingServices>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<ISupplierCredentialRepository, SupplierCredentialRepository>();
builder.Services.AddScoped<IAdministratorCredentialRepository, AdministratorCredentialRepository>();
builder.Services.AddScoped<IAdministratorCredentialCommandService, AdministratorCredentialCommandService>();
builder.Services.AddScoped<IAdministratorCredentialQueryService, AdministratorCredentialQueryService>();
builder.Services.AddScoped<ISupplierCredentialRepository, SupplierCredentialRepository>();
builder.Services.AddScoped<ISupplierCredentialCommandService, SupplierCredentialCommandService>();
builder.Services.AddScoped<ISupplierCredentialQueryService, SupplierCredentialQueryService>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IAdministratorCommandService, AdministratorCommandService>();
builder.Services.AddScoped<IAdministratorQueryService, AdministratorQueryService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierCommandService, SupplierCommandService>();
builder.Services.AddScoped<ISupplierQueryService, SupplierQueryService>();

builder.Services.AddScoped<DatabaseInitializer>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
    });
});

#region TOKEN CONFIGURATION

var tokenSettings = builder.Configuration.GetSection("TokenSettings");

builder.Services.Configure<TokenSettings>(tokenSettings);

var secretKey = tokenSettings["Secret"];

var audience = tokenSettings["Audience"];

var issuer = tokenSettings["Issuer"];

var securityKey = !string.IsNullOrEmpty(secretKey)
    ? new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey))
    : throw new ArgumentException("Secret key is null or empty");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = securityKey,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<TokenValidationHandler>();

builder.Services.AddAuthorization();

#endregion

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