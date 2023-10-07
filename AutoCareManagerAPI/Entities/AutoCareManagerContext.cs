using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Entities;

public partial class AutoCareManagerContext : DbContext
{
    public AutoCareManagerContext()
    {
    }

    public AutoCareManagerContext(DbContextOptions<AutoCareManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Configuracion> Configuracion { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<ServicioRealizados> ServicioRealizados { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VHTS6CI;Database=AutoCareManager; TrustServerCertificate=True;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE0D166054");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numDocumento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Configur__40F9A207C006BA42");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Grupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("grupo");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297CDFFCF050");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cargo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ServicioRealizados>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB981194A13E8CE");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.Servicio1).HasColumnName("Servicio");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdSercicios).HasName("PK__Servicio__79861A36A69509A1");

            entity.Property(e => e.IdSercicios).HasColumnName("idSercicios");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A652E69EFF");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__4868297049555B19");

            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.Anio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("anio");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("placa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
