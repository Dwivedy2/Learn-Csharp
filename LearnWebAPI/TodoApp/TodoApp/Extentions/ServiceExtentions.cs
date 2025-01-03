using Microsoft.EntityFrameworkCore;
using Database;
using Contract;
using Repository;

namespace TodoApp.Extentions
{
    public static class ServiceExtentions
    {
        // Swagger 
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen();
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

        // Repositories
        public static void ConfigureRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
