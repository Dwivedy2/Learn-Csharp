using TodoApp.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Swagger
builder.Services.ConfigureSwaggerGen();
// Database
builder.Services.ConfigureDbContext(builder.Configuration);
// CORS
builder.Services.ConfigureCORS("DefaultPolicy");
// Services
builder.Services.ConfigureRepoServices();
// Authentication Middleware
builder.Services.ConfigureAuth("Bearer");
builder.Services.AddAuthorization();
builder.Services.ConfigureJwtToken();

var app = builder.Build();

// Activating Middleware
app.UseAuthentication();
app.UseAuthorization();

app.ConfigureSwaggerDoc();

// Configure the HTTP request pipeline.

app.UseCors("DefaultPolicy");

// Global Exception Handler
app.ConfigureGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
