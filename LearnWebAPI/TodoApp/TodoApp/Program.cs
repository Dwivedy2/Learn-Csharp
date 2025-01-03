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

var app = builder.Build();

app.ConfigureSwaggerDoc();

// Configure the HTTP request pipeline.
app.UseCors("DefaultPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
