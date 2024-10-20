using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Todo.Contracts;
using Todo.Repository;
using AutoMapper;

namespace Todo.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];

            services.AddDbContext<RepoContext>(o => o.UseMySql(connectionString, 
                MySqlServerVersion.LatestSupportedServerVersion));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        public static void ConfigureSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AccountOwner",
                });
            });
        }

        //public static void ConfigureTodoRepo(this IServiceCollection services)
        //{
        //    services.AddScoped<ITodoRepo, ToDoRepo>();
        //}

        //public static void ConfigureUserRepo(this IServiceCollection services)
        //{
        //    services.AddScoped<IUserRepo, UserRepo>();
        //}

        public static void ConfigureRepoWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }
    }
}
