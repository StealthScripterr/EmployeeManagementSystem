using EmployeeManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Persistence
{
    public class EmployeeDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Designation> Designations => Set<Designation>();
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.ContactNumber)
                      .HasMaxLength(30);

                entity.Property(e => e.Status)
                      .HasConversion<int>()
                      .IsRequired();

                entity.Property(e => e.DateOfJoining)
                      .HasColumnType("date");

                entity.HasOne<Department>()
                      .WithMany()
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Designation>()
                      .WithMany()
                      .HasForeignKey(e => e.DesignationId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                      .ValueGeneratedOnAdd()
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(d => d.Description)
                      .HasMaxLength(1000);

                entity.HasIndex(d => d.Name).IsUnique();
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designations");
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                      .ValueGeneratedOnAdd()
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(d => d.Description)
                      .HasMaxLength(1000);

                entity.HasIndex(d => d.Name).IsUnique();
            });
        }

    }
}
