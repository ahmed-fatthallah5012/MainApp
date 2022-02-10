using Microsoft.EntityFrameworkCore;

namespace MainApp.DataModels;

public sealed class SystemContext : DbContext
{
    public SystemContext()
    {
        Database.Migrate();

    }

    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server = . ; Database = MainErrors; Trusted_connection = true;");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");
            entity.Property(a => a.Name).HasMaxLength(250);
            entity.Property(a => a.Phone).HasColumnType("char(11)").IsUnicode();
        });
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable(nameof(Employee));
            entity.HasMany(a => a.Departments)
                .WithMany(a => a.Employees)
                .UsingEntity<Dictionary<string, object>>("EmployeeDepartment", a =>
                    a.HasOne<Department>()
                        .WithMany()
                        .HasForeignKey("Department"), a => a
                    .HasOne<Employee>()
                    .WithMany()
                    .HasForeignKey("Employee"), a =>
                {
                    a.ToTable("EmployeeDepartment");
                    a.HasKey("Employee", "Department");
                });
        });
        modelBuilder.Entity<Client>().ToTable(nameof(Client));
        base.OnModelCreating(modelBuilder);
    }
}