using Microsoft.EntityFrameworkCore;
using Tfi.Domain.Entities;

namespace Tfi.Data.Context;

public partial class TfiContext : DbContext
{
    public TfiContext()
    {
    }

    public TfiContext(DbContextOptions<TfiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Funcionalidad> Funcionalidads { get; set; }

    public virtual DbSet<HistorialCambio> HistorialCambios { get; set; }

    public virtual DbSet<Incidencium> Incidencia { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("idCliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(45)
                .HasColumnName("direccionCliente");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.MailCliente)
                .HasMaxLength(45)
                .HasColumnName("mailCliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(45)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(45)
                .HasColumnName("telefonoCliente");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(45)
                .HasColumnName("tipoCliente");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.IdUsuario, "fk_empleado_usuario1_idx").IsUnique();

            entity.Property(e => e.Id).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(45)
                .HasColumnName("apellidoEmpleado");
            entity.Property(e => e.DireccionEmpleado)
                .HasMaxLength(45)
                .HasColumnName("direccionEmpleado");
            entity.Property(e => e.DniEmpleado).HasColumnName("dniEmpleado");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.MailEmpleado)
                .HasMaxLength(45)
                .HasColumnName("mailEmpleado");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(45)
                .HasColumnName("nombreEmpleado");
            entity.Property(e => e.RolEmpleado).HasColumnName("rolEmpleado");
            entity.Property(e => e.TelefonoEmpleado)
                .HasMaxLength(10)
                .HasColumnName("telefonoEmpleado");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Empleado)
                .HasForeignKey<Empleado>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleado_usuario1");

            entity.HasMany(d => d.Equipos).WithMany(p => p.Empleados)
                .UsingEntity<Dictionary<string, object>>(
                    "EmpleadoPorEquipo",
                    r => r.HasOne<Equipo>().WithMany()
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_empleado_por_equipo_equipo1"),
                    l => l.HasOne<Empleado>().WithMany()
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_empleado_por_equipo_empleado1"),
                    j =>
                    {
                        j.HasKey("IdEmpleado", "IdEquipo")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("empleado_por_equipo");
                        j.HasIndex(new[] { "IdEmpleado" }, "fk_empleado_por_equipo_empleado1_idx");
                        j.HasIndex(new[] { "IdEquipo" }, "fk_empleado_por_equipo_equipo1_idx");
                        j.IndexerProperty<int>("IdEmpleado").HasColumnName("idEmpleado");
                        j.IndexerProperty<int>("IdEquipo").HasColumnName("idEquipo");
                    });
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipo");

            entity.Property(e => e.Id).HasColumnName("idEquipo");
            entity.Property(e => e.NumeroEquipo).HasColumnName("numeroEquipo");
        });

        modelBuilder.Entity<Funcionalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcionalidad");

            entity.HasIndex(e => e.IdProyecto, "fk_funcionalidad_proyecto1_idx");

            entity.Property(e => e.Id).HasColumnName("idFuncionalidad");
            entity.Property(e => e.DescripcionFuncionalidad)
                .HasMaxLength(45)
                .HasColumnName("descripcionFuncionalidad");
            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.NombreFuncionalidad)
                .HasMaxLength(45)
                .HasColumnName("nombreFuncionalidad");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Funcionalidades)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funcionalidad_proyecto1");

            entity.HasMany(d => d.HistorialCambios).WithMany(p => p.Funcionalidades)
                .UsingEntity<Dictionary<string, object>>(
                    "HistorialTieneFuncionalidade",
                    r => r.HasOne<HistorialCambio>().WithMany()
                        .HasForeignKey("IdHistorialCambio")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_historial_tiene_funcionalidades_historial_funcionalidad_ca1"),
                    l => l.HasOne<Funcionalidad>().WithMany()
                        .HasForeignKey("IdFuncionalidad")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_historial_tiene_funcionalidades_funcionalidad1"),
                    j =>
                    {
                        j.HasKey("IdFuncionalidad", "IdHistorialCambio")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("historial_tiene_funcionalidades");
                        j.HasIndex(new[] { "IdFuncionalidad" }, "fk_historial_tiene_funcionalidades_funcionalidad1_idx");
                        j.HasIndex(new[] { "IdHistorialCambio" }, "fk_historial_tiene_funcionalidades_historial_funcionalidad__idx");
                        j.IndexerProperty<int>("IdFuncionalidad").HasColumnName("idFuncionalidad");
                        j.IndexerProperty<int>("IdHistorialCambio").HasColumnName("idHistorial_cambio");
                    });
        });

        modelBuilder.Entity<HistorialCambio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("historial_cambio");

            entity.HasIndex(e => e.IdEmpleado, "fk_historial_funcionalidad_cambio_empleado1_idx");

            entity.HasIndex(e => e.IdProyecto, "fk_historial_funcionalidad_cambio_proyecto1_idx");

            entity.Property(e => e.Id).HasColumnName("idHistorial_cambio");
            entity.Property(e => e.FechaCambio).HasColumnName("fechaCambio");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.MotivoCambio)
                .HasMaxLength(45)
                .HasColumnName("motivoCambio");
            entity.Property(e => e.Presupuesto).HasColumnName("presupuesto");

            entity.HasOne(d => d.Empleado).WithMany(p => p.HistorialCambios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historial_funcionalidad_cambio_empleado1");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.HistorialCambios)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historial_funcionalidad_cambio_proyecto1");
        });

        modelBuilder.Entity<Incidencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("incidencia");

            entity.HasIndex(e => e.IdProyecto, "fk_incidencia_proyecto1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idIncidencia");
            entity.Property(e => e.DescripcionIncidencia)
                .HasMaxLength(45)
                .HasColumnName("descripcionIncidencia");
            entity.Property(e => e.FechaIncidencia).HasColumnName("fechaIncidencia");
            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.TipoIncidencia)
                .HasMaxLength(45)
                .HasColumnName("tipoIncidencia");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_incidencia_proyecto1");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proyecto");

            entity.HasIndex(e => e.IdCliente, "fk_proyecto_cliente1_idx");

            entity.HasIndex(e => e.IdEquipo, "fk_proyecto_equipo1_idx");

            entity.Property(e => e.Id).HasColumnName("idProyecto");
            entity.Property(e => e.EstadoProyecto)
                .HasColumnName("estadoProyecto");
            entity.Property(e => e.FechaFinProyecto).HasColumnName("fechaFinProyecto");
            entity.Property(e => e.FechaInicioPreyecto).HasColumnName("fechaInicioPreyecto");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(45)
                .HasColumnName("nombreProyecto");
            entity.Property(e => e.PresupuestoProyecto).HasColumnName("presupuestoProyecto");
            entity.Property(e => e.TipoProyecto)
                .HasMaxLength(45)
                .HasColumnName("tipoProyecto");
            entity.Property(e => e.PrioridadProyecto)
                  .HasColumnName("prioridadProyecto");
            entity.Property(e => e.DescripcionProyecto)
                  .HasMaxLength(150)
                  .HasColumnName("prioridadProyecto");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_proyecto_cliente1");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_proyecto_equipo1");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("recurso");

            entity.Property(e => e.Id).HasColumnName("idRecurso");
            entity.Property(e => e.DescripcionRecurso)
                .HasMaxLength(45)
                .HasColumnName("descripcionRecurso");

            entity.HasMany(d => d.Tareas).WithMany(p => p.Recursos)
                .UsingEntity<Dictionary<string, object>>(
                    "TareaTieneRecurso",
                    r => r.HasOne<Tarea>().WithMany()
                        .HasForeignKey("IdTarea")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tarea_tiene_recursos_tarea1"),
                    l => l.HasOne<Recurso>().WithMany()
                        .HasForeignKey("IdRecurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tarea_tiene_recursos_recurso1"),
                    j =>
                    {
                        j.HasKey("IdRecurso", "IdTarea")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("tarea_tiene_recursos");
                        j.HasIndex(new[] { "IdRecurso" }, "fk_tarea_tiene_recursos_recurso1_idx");
                        j.HasIndex(new[] { "IdTarea" }, "fk_tarea_tiene_recursos_tarea1_idx");
                        j.IndexerProperty<int>("IdRecurso").HasColumnName("idRecurso");
                        j.IndexerProperty<int>("IdTarea").HasColumnName("idTarea");
                    });
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tarea");

            entity.HasIndex(e => e.IdEmpleado, "fk_tarea_empleado1_idx");

            entity.HasIndex(e => e.IdFuncionalidad, "fk_tarea_funcionalidad1_idx");

            entity.Property(e => e.Id).HasColumnName("idTarea");
            entity.Property(e => e.DescripcionTarea)
                .HasMaxLength(45)
                .HasColumnName("descripcionTarea");
            entity.Property(e => e.EstadoTarea)
                .HasColumnName("estadoTarea");
            entity.Property(e => e.FechaFinTarea).HasColumnName("fechaFinTarea");
            entity.Property(e => e.FechaInicioTarea).HasColumnName("fechaInicioTarea");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdFuncionalidad).HasColumnName("idFuncionalidad");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(45)
                .HasColumnName("nombreTarea");
            entity.Property(e => e.PrioridadTarea)
                .HasColumnName("prioridadTarea");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tarea_empleado1");

            entity.HasOne(d => d.Funcionalidad).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdFuncionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tarea_funcionalidad1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.NombreUsuario, "nombreUsuario_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("idUsuario");
            entity.Property(e => e.ContraseniaUsuario)
                .HasMaxLength(65)
                .HasColumnName("contraseniaUsuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(45)
                .HasColumnName("nombreUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
