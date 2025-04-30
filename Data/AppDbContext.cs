using Microsoft.EntityFrameworkCore;
using AventureoBack.Models;

namespace AventureoBack.Data
{
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

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Planes)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.idUsuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Viajes)
                .WithOne(v => v.Usuario)
                .HasForeignKey(v => v.idUsuario);

            modelBuilder.Entity<Plan>()
                .HasMany(p => p.PartesPlan)
                .WithOne(pp => pp.Plan)
                .HasForeignKey(pp => pp.idPlan);

            modelBuilder.Entity<Viaje>()
                .HasMany(v => v.Gastos)
                .WithOne(g => g.Viaje)
                .HasForeignKey(g => g.idViaje);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Gastos)
                .WithOne(g => g.Categoria)
                .HasForeignKey(g => g.idCategoria);
        }
    }
}
