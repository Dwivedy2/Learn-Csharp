using PasswordManager.Extention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.UseSwaggerG();

builder.Services.ConfigureDb(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerDoc();

app.MapControllers();

app.Run();
