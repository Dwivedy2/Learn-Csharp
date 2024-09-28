var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// This policy name will be used to allow CORS
const string POLICY_NAME = "CorsPolicy";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: POLICY_NAME, builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//    });
//});

// Only single policy is ok, use default one
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Policy name is passed, this way is prefered when having multiple policies
// app.UseCors(POLICY_NAME);

// For default cors
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
