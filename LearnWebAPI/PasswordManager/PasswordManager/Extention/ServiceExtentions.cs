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
    }
}
