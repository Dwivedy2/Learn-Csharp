using Contracts;
using LoggerService;

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
    }
}
