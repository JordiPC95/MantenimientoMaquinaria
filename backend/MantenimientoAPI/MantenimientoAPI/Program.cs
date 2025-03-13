using MantenimientoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;  // Para Swagger
using Microsoft.AspNetCore.Builder;  // Para WebApplication
using Microsoft.Extensions.DependencyInjection;  // Para AddDbContext y servicios
using Microsoft.Extensions.Hosting;  // Para configurar el entorno


var builder = WebApplication.CreateBuilder(args);

// Configurar conexión con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Habilitar los controladores de la API

app.Run();
