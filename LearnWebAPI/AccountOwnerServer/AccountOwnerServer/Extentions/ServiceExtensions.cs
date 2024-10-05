using Contracts;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AccountOwnerServer.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureCors(this IServiceCollection services, string POLICY_NAME)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(POLICY_NAME, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader() 
                    .AllowAnyMethod();
                });
            });

            // When no policy name is specified
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});
        }
        
        public static void ConfigureLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];

            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString, 
                MySqlServerVersion.LatestSupportedServerVersion));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
