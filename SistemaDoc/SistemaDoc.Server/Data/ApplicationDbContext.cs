using Microsoft.EntityFrameworkCore;
using SistemaDoc.Shared.Models;
namespace SistemaDoc.Server.Data
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Certificacion> Certificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Nombre = "Salud" },
                new Area { Id = 2, Nombre = "Educacion" },
                new Area { Id = 3, Nombre = "Parque y Jardines" }
              
            );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Name = "Mantenimiento" },
                new Categoria { Id = 2, Name = "Refaccion" },
                new Categoria { Id = 3, Name = "Instalacion" }

            );
        }
    }
}
