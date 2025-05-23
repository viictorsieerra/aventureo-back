using Aventureo_Back.Repository.Interfaces;
using Aventureo_Back.Service;
using Aventureo_Back.Service.Interfaces;
using AventureoBack.Data;
using AventureoBack.Repositories;
using AventureoBack.Services;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using TuProyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("AventureoDB");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registro de repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IGastoRepository, GastoRepository>();
builder.Services.AddScoped<IGastoService, GastoService>();

builder.Services.AddScoped<IJwtAuthService, JwtAuthService>();

builder.Services.AddScoped<IPartePlanRepository, PartePlanRepository>(provider =>
    new PartePlanRepository(connectionString));
builder.Services.AddScoped<IPlanRepository, PlanRepository>(provider =>
    new PlanRepository(connectionString));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IViajeRepository, ViajeRepository>(provider =>
    new ViajeRepository(connectionString));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Servicios de controllers
builder.Services.AddControllers();

// HttpClient (para servicios externos como OpenAI)
builder.Services.AddHttpClient();

builder.Services.AddSingleton<OpenAIService>();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // URL de tu frontend Vue
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // si usas cookies o auth
    });
});

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

app.UseCors("AllowAll");          // **Debe ir antes de UseAuthorization**

app.UseHttpsRedirection();        // Opcional, comentalo si da problemas de SSL

app.UseAuthorization();

app.MapControllers();

app.Run();
