using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Custom.Middleware;
using PasswordManager.Database;
using PasswordManager.Interfaces;
using PasswordManager.Services;
using Serilog;

namespace PasswordManager.Extention
{
    public static class ServiceExtentions
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
        }

        public static void UseSwaggerG(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        public static void UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "PasswordManager");
            });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }

        public static void ConfigureSeriLog(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }

        public static void UseCustomMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
