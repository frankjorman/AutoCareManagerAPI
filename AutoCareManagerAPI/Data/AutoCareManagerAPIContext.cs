using AutoCareManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Data
{
    public class AutoCareManagerAPIContext:DbContext
    {
        public AutoCareManagerAPIContext(DbContextOptions options) :base(options) { }

        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Reparacion> reparacion { get; set; }
        public DbSet<Vehiculo> vehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
