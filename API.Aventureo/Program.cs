using API.Aventureo.Extensions;
using API.Aventureo.Models;
using Application.Aventureo.Extensions;
using Application.Aventureo.Services;
using Core.Aventureo.Interfaces.Service;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("AventureoDB");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Añadido de capas

builder.Services.AddInfraestructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddExternalCommunication(builder.Configuration);
builder.Services.AddJwtSecurity(builder.Configuration);

// Servicios de controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (opcional)
builder.Services.AddCors(o => o.AddPolicy("AllowAll", p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aventureo API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseMiddleware<Middleware>();
app.MapControllers();
app.Run();