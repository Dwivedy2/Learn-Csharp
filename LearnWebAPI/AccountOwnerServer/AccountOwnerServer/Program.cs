using AccountOwnerServer.Extentions;
using AccountOwnerServer.Constants;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "/nlog.config");
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "nlog.config"));

// Add services to the container.

builder.Services.ConfigureCors(Constants.POLICY_NAME);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLogging();
builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureAutoMapper();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
else 
    app.UseHsts();

// If no policyname is specified, app.UseCors();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

app.UseCors(Constants.POLICY_NAME);

app.UseAuthorization();

app.MapControllers();

app.Run();
