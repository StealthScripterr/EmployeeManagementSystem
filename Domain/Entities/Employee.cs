using EmployeeManagementSystem.Domain.Enums;
namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? ContactNumber { get; set; } = null;
        public EmployeeStatus Status { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DesignationId { get; set; }

    }
}
