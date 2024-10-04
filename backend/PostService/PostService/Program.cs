using AutoMapper;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using PostService.Interfaces;
using PostService.Models;
using PostService.Repositories;
using PostService.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PostService.Grpc;
using Grpc.Core;
using Grpc.Net.Client;


var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging


// Configure services
ConfigureServices(builder.Services, builder.Configuration);



var app = builder.Build();

// Configure middleware
ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Configure MongoDB settings
    services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));
    services.AddSingleton<IMongoClient, MongoClient>(sp =>
        new MongoClient(configuration.GetValue<string>("MongoDB:ConnectionString")));

    // Configure gRPC client
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

    var channel = GrpcChannel.ForAddress("http://localhost:5173", new GrpcChannelOptions { HttpHandler = handler });
    var client = new UserService.UserServiceClient(channel);

    services.AddSingleton(client);

    // Register services and repositories
    services.AddSingleton<MongoDBContext>();
    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<IPostService, PostService.Services.Postservice>();
    services.AddScoped<ICommentRepository, CommentRepository>();
    services.AddScoped<ICommentService, CommentService>();
    services.AddScoped<ILikeRepository, LikeRepository>();
    services.AddScoped<ILikeService, LikeService>();
    services.AddScoped<ISavedPostRepository, SavedPostRepository>();
    services.AddScoped<ISavedPostService, SavedPostService>();
    services.AddSingleton<GrpcUserClientService>();

    // Add AutoMapper
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Add Swagger
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Post Management Service API",
            Version = "v1",
            Description = "API documentation for Post Management Service",
            Contact = new OpenApiContact
            {
                Name = "Mohamed Gomaa",
                Email = "mohamed@gmail.com",
            },
            License = new OpenApiLicense
            {
                Name = "Use under XYZ",
                Url = new Uri("https://license-url.com"),
            }
        });

        // Enable support for JWT bearer tokens
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });
services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false;
});

    // Add controllers
    services.AddControllers();

    // Add CORS
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

}

void ConfigureMiddleware(WebApplication app)
{
    // Enable Swagger and Swagger UI in all environments
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Post Management Service API v1");
        c.DocumentTitle = "Post Management Service API Docs";
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });

    // Enable CORS
    app.UseCors("AllowAll");

    // Add Exception Handling Middleware
    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}
