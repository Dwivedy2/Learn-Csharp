using PasswordManager.Extention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.UseSwaggerG();

builder.Services.ConfigureSeriLog(builder);

builder.Services.ConfigureDb(builder.Configuration);

builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomMiddleware();

app.UseSwaggerDoc();

app.MapControllers();

app.Run();
