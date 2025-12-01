using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Persistence
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Designation> Designations => Set<Designation>();
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(200);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
