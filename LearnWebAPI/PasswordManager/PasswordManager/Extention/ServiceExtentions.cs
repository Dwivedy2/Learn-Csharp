using Microsoft.EntityFrameworkCore;
using PasswordManager.Database;

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
    }
}
