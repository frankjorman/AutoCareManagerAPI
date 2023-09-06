using AutoCareManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Data
{
    public class AutoCareManagerAPIContext:DbContext
    {
        public AutoCareManagerAPIContext(DbContextOptions options) :base(options) { }

        public DbSet<Mecanico> Mecanico { get; set; }
        public DbSet<Reparaciones> Reparaciones { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
