using AventureoBack.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Configurar cadena de conexión (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Ejemplo en appsettings.json:
// "ConnectionStrings": {
//   "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AventureoDb;Trusted_Connection=True;"
// }

//  Registrar el DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Añadir servicios MVC / Controllers
builder.Services.AddControllers();

// (Opcional) Añadir Swagger para documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS si tu frontend está en otro origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Middleware pipeline

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
