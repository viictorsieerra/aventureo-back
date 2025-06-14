using Microsoft.EntityFrameworkCore;
using Core.Aventureo.Entities;

namespace Infraestructure.Aventureo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Plan> Planes { get; set; }
    public DbSet<PartePlan> PartesPlan { get; set; }
    public DbSet<Viaje> Viajes { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relaciones Usuario - Plan
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.planes)
            .WithOne(p => p.usuario)
            .HasForeignKey(p => p.idUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones Usuario - Viaje
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.viajes)
            .WithOne(v => v.usuario)
            .HasForeignKey(v => v.idUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones Plan - PartePlan
        modelBuilder.Entity<Plan>()
            .HasMany(p => p.partesPlan)
            .WithOne(pp => pp.plan)
            .HasForeignKey(pp => pp.idPlan)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones Viaje - Gasto
        modelBuilder.Entity<Viaje>()
            .HasMany(v => v.gastos)
            .WithOne(g => g.viaje)
            .HasForeignKey(g => g.idViaje)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones Categoria - Gasto
        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Gastos)
            .WithOne(g => g.categoria)
            .HasForeignKey(g => g.idCategoria)
            .OnDelete(DeleteBehavior.Restrict);

        // Email de usuario Unico
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.email)
            .IsUnique();
    }
}
