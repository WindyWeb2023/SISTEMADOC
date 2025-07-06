using Microsoft.EntityFrameworkCore;
using SistemaDoc.Shared.Models;
namespace SistemaDoc.Server.Data
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
