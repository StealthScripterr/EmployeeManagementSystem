using EmployeeManagementSystem.Domain.Enums;
namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        private Employee() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? ContactNumber { get; private set; } = null;
        public EmployeeStatus Status { get; private set; }
        public DateOnly DateOfJoining { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Guid DesignationId { get; private set; }

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
