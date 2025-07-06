using Microsoft.EntityFrameworkCore;
using SistemaDoc.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var corsPolicyName = "AllowClient";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.WithOrigins("https://localhost:7169") // Puerto del Client
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(corsPolicyName);
app.MapControllers();

app.Run();
