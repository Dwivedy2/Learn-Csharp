using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Database;
using Contract;
using Repository;
using System.Text;
using Common;
using CustomMiddlewares;
using Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Extentions
{
    public static class ServiceExtentions
    {
        // Swagger 
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.\nExample: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
                });
                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        public static void ConfigureSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp API");
            });
        }

        // Database
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("Database")));
        }

        // CORS
        public static void ConfigureCORS(this IServiceCollection services, string policyName)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(policyName, opt =>
                {
                    opt.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
        }

        // Authentication
        public static void ConfigureAuth(this IServiceCollection services, string authName, WebApplicationBuilder builder)
        {
            services.AddAuthentication(authName)
                .AddJwtBearer(authName, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
        }

        // Jwt Service
        public static void ConfigureJwtToken(this IServiceCollection services)
        {
            // services.AddSingleton(new JwtTokenGenerator("Test", "Test", "SecretKey"));
            services.AddSingleton<IJwtTokenGenerator>(new JwtTokenGenerator("https://yourissuer.com", 
                "https://youraudience.com", "YourVeryStrongSecretKeyWith32Chars!"));
        }

        // Automapper
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }

        // Repositories
        public static void ConfigureRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSingleton<ICustomLogService, CustomLogService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<LoggingFilter>();
            services.AddScoped<ValidationFilter>();
            services.AddScoped<ExceptionFilter>();
            //services.AddScoped<AuthFilter>();
            services.AddScoped<AuthActionFilter>();
        }

        // Suppress Model State Default
        public static void ConfigureSuppressDefaultState(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

        // Middlewares
        public static void CustomUseMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<UseHeaderInjection>();
            app.UseMiddleware<UseLogging>();
            app.UseMiddleware<UseShortCircuiting>();
            app.UseMiddleware<UseCommonExceptionHandling>();
        }
    }
}
