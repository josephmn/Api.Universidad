using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Habilitar anotaciones Swagger
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "API implementado con Asp.Net Core 6 - Reto Técnico",
        Title = "API Universidad",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Joseph Magallanes Nolazco",
            Url = new Uri("https://github.com/josephmn")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
