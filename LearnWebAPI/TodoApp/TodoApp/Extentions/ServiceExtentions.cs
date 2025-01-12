using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Database;
using Contract;
using Repository;
using System.Text;
using Common;

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
        public static void ConfigureAuth(this IServiceCollection services, string authName)
        {
            services.AddAuthentication(authName)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://yourissuer.com",
                        ValidAudience = "https://youraudience.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourVeryStrongSecretKeyWith32Chars!"))
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

        // Repositories
        public static void ConfigureRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
