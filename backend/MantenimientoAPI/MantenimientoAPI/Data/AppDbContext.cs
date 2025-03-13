using Microsoft.EntityFrameworkCore;
using MantenimientoAPI.Models;

namespace MantenimientoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Maquinaria> Maquinarias { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }
}
