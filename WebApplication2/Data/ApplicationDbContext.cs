using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Producto> Productos { get; set; } = default!;

        public DbSet<Proveedor> Proveedores { get; set; } = default!;

        public DbSet<Categoria> Categorias { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Producto>().ToTable(nameof(Producto));
            builder.Entity<Proveedor>().ToTable(nameof(Proveedor));
            builder.Entity<Categoria>().ToTable(nameof(Categoria));

            builder.Entity<Proveedor>()
                .HasMany(p => p.Productos)
                .WithOne(p => p.Proveedor)
                .HasForeignKey(p => p.ProveedorId);

            builder.Entity<Categoria>()
                .HasMany(p => p.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
        }

        
    }
}
