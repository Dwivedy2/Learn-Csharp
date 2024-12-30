namespace TodoApp.Extentions
{
    public static class ServiceExtentions
    {
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
    }
}
