using AventureoBack.Data;
using AventureoBack.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("AventureoDB");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registro de repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IGastoRepository, GastoRepository>(provider =>
new GastoRepository(connectionString));

builder.Services.AddScoped<IPartePlanRepository, PartePlanRepository>(provider =>
new PartePlanRepository(connectionString));
builder.Services.AddScoped<IPlanRepository, PlanRepository>(provider =>
new PlanRepository(connectionString));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(provider =>
new UsuarioRepository(connectionString));
builder.Services.AddScoped<IViajeRepository, ViajeRepository>(provider =>
new ViajeRepository(connectionString));

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
app.UseAuthorization();
app.MapControllers();
app.Run();