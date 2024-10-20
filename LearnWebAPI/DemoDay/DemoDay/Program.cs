using DemoDay;
using DemoDay.Implementations;
using DemoDay.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RepoContext>(op => op.UseMySql(builder.Configuration["mysqlconnection:connectionString"], 
    MySqlServerVersion.LatestSupportedServerVersion));
builder.Services.AddScoped<IDb, Db>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
