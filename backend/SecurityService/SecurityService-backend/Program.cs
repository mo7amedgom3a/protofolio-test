using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using SecurityService.Models;
using AutoMapper;
using SecurityServiceBackend.Configurations;
using Microsoft.OpenApi.Models;
using SecurityServiceBackend.Repositories;
using SecurityServiceBackend.Interfaces;
using SecurityServiceBackend.Services;
using SecurityService.Helpers;
using SecurityServiceBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure Middleware
ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Configure MySQL
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
        var connection = configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connection, serverVersion);
    });

    // Configure Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

    // AutoMapper configuration
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Configure JWT Authentication
    var jwtKey = configuration["JWT:Key"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new ArgumentNullException(nameof(jwtKey), "JWT Key is not configured.");
    }
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidAudience = configuration["JWT:Audience"],
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
    });

    var jwtConfig = configuration.GetSection("Jwt").Get<JwtConfig>();
    services.Configure<JwtConfig>(configuration.GetSection("Jwt"));

    // Register Repositories and Services for Dependency Injection
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
    // Add Authorization
    services.AddAuthorization();

    // Add Controllers
    services.AddControllers();

    // Add Swagger services
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        // Add JWT Authentication to Swagger
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }});
    });
}

void ConfigureMiddleware(WebApplication app)
{
    // Middleware configuration
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseHsts();
    }
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });

    app.MapControllers();
}