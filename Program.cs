using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MyBackendProject.Data;

var builder = WebApplication.CreateBuilder(args);

// MySQL connection string
var connectionString = "server=localhost;port=3306;database=dotnetpractice;user=root;password=root";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// ✅ Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers();
var app = builder.Build();

//modified
app.Urls.Add("http://0.0.0.0:5000");


// ✅ Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello world");
app.MapControllers();
app.Run();
