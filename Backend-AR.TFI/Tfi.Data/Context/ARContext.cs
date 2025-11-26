using Microsoft.EntityFrameworkCore;
using System.Threading;
using Tfi.Domain.Entities;

namespace Tfi.Data.Context;

public class ARContext : DbContext
{
    public ARContext(DbContextOptions<ARContext> options) : base(options)
    {

    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Function> Functions { get; set; }
    public DbSet<ChangeHistory> ChangesHistory { get; set; }
    public DbSet<Incidence> Incidences { get; set; }
    public DbSet<Proyect> Proyects { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Tfi.Domain.Entities.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCliente(modelBuilder);
        ConfigureEmpleado(modelBuilder);
        ConfigureEquipo(modelBuilder);
        ConfigureFuncionalidad(modelBuilder);
        ConfigureHistorialCambio(modelBuilder);
        ConfigureIncidencia(modelBuilder);
        ConfigureProyecto(modelBuilder);
        ConfigureRecurso(modelBuilder);
        ConfigureTarea(modelBuilder);
        ConfigureUsuario(modelBuilder);
    }
    private void ConfigureCliente(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("clientes");
            entity.Property(e => e.Direction).HasMaxLength(45).HasColumnName("direccionCliente");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.Mail).HasMaxLength(45).HasColumnName("mailCliente");
            entity.Property(e => e.Name).HasMaxLength(45).HasColumnName("nombreCliente");
            entity.Property(e => e.Phone).HasMaxLength(45).HasColumnName("telefonoCliente");
        });
    }
    private void ConfigureEmpleado(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("empleados");
            entity.Property(e => e.LastName).HasMaxLength(45).HasColumnName("apellidoEmpleado");
            entity.Property(e => e.Direction).HasMaxLength(45).HasColumnName("direccionEmpleado");
            entity.Property(e => e.Dni).HasColumnName("dniEmpleado");
            entity.Property(e => e.Mail).HasMaxLength(45).HasColumnName("mailEmpleado");
            entity.Property(e => e.Name).HasMaxLength(45).HasColumnName("nombreEmpleado");
            entity.Property(e => e.RolEmpleado).HasColumnName("rolEmpleado");
            entity.Property(e => e.Phone).HasMaxLength(10).HasColumnName("telefonoEmpleado");
        });
    }
    private void ConfigureEquipo(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("equipos");
            entity.Property(e => e.Number).HasColumnName("numeroEquipo");
        });
    }
    private void ConfigureFuncionalidad(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Function>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("funcionalidades");
            entity.Property(e => e.Description).HasMaxLength(45).HasColumnName("descripcionFuncionalidad");
            entity.Property(e => e.Name).HasMaxLength(45).HasColumnName("nombreFuncionalidad");
        });
    }
    private void ConfigureHistorialCambio(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChangeHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("historial_cambios");
            entity.Property(e => e.ChangeDate).HasColumnName("fechaCambio");
            entity.Property(e => e.Reason).HasMaxLength(45).HasColumnName("motivoCambio");
            entity.Property(e => e.Budget).HasColumnName("presupuesto");
            entity.Property(e => e.FunctionsSnapshot).HasColumnName("oldFunctions");
        });
        modelBuilder.Entity<ChangeHistory>()
            .HasOne(h => h.Proyect)
            .WithMany(p => p.ChangesHistory)
            .HasForeignKey(h => h.ProyectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChangeHistory>()
            .HasOne(h => h.Employee)
            .WithMany(e => e.ChangesHistory)
            .HasForeignKey(h => h.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    private void ConfigureIncidencia(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incidence>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("incidencias");
            entity.Property(e => e.Description).HasMaxLength(45).HasColumnName("descripcionIncidencia");
            entity.Property(e => e.RegisterDate).HasColumnName("fechaIncidencia");
            entity.Property(e => e.Type).HasMaxLength(45).HasColumnName("tipoIncidencia");
        });
    }
    private void ConfigureProyecto(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proyect>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("proyectos");
            entity.Property(e => e.State).HasColumnName("estadoProyecto");
            entity.Property(e => e.DateEnd).HasColumnName("fechaFinProyecto");
            entity.Property(e => e.DateInitial).HasColumnName("fechaInicioPreyecto");
            entity.Property(e => e.Name).HasMaxLength(45).HasColumnName("nombreProyecto");
            entity.Property(e => e.Budget).HasColumnName("presupuestoProyecto");
            entity.Property(e => e.Type).HasMaxLength(45).HasColumnName("tipoProyecto");
            entity.Property(e => e.Priority).HasColumnName("prioridadProyecto");
            entity.Property(e => e.Description).HasMaxLength(150).HasColumnName("descripcionProyecto");
        });
    }
    private void ConfigureRecurso(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("recursos");
            entity.Property(e => e.Description).HasMaxLength(100).HasColumnName("descripcionRecurso");
        });
    }
    private void ConfigureTarea(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tfi.Domain.Entities.Task>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("tareas");
            entity.Property(e => e.Description).HasMaxLength(150).HasColumnName("descripcionTarea");
            entity.Property(e => e.State).HasColumnName("estadoTarea");
            entity.Property(e => e.EndDate).HasColumnName("fechaFinTarea");
            entity.Property(e => e.InitialDate).HasColumnName("fechaInicioTarea");
            entity.Property(e => e.Name).HasMaxLength(45).HasColumnName("nombreTarea");
            entity.Property(e => e.Priority).HasColumnName("prioridadTarea");
            entity.Property(e => e.ImplementationStatus).HasColumnName("estadoImplementación");
        });
        modelBuilder.Entity<Domain.Entities.Task>()
            .HasOne(t => t.Function)
            .WithMany(f => f.Tasks)
            .HasForeignKey(t => t.FunctionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    private void ConfigureUsuario(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("usuarios");
            entity.Property(e => e.Password).HasMaxLength(65).HasColumnName("contraseniaUsuario");
            entity.Property(e => e.UserName).HasMaxLength(45).HasColumnName("nombreUsuario");
        });
    }

}
