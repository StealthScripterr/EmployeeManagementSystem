using EmployeeManagementSystem.Domain.Enums;
namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ContactNumber { get; set; } = null;
        public EmployeeStatus Status { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DesignationId { get; set; }

        public void ChangeStatus(EmployeeStatus newStatus)
        {
            if (Status == newStatus)
            {
                return;
            }

            // In future: validate transitions here.
            Status = newStatus;
        }
        public Employee(string name, string? contactNumber, DateOnly? dateofJoining, Guid departmentId, Guid designationId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            Name = name;
            ContactNumber = contactNumber;
            DateOfJoining = dateofJoining ?? DateOnly.FromDateTime(DateTime.UtcNow);
            DepartmentId = departmentId;
            DesignationId = designationId;
            Status = EmployeeStatus.Active;
        }
    }
}
