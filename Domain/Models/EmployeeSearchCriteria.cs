using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Models
{
    public class EmployeeSearchCriteria
    {
        public string? Name { get; init; }
        public Guid? DepartmentId { get; init; }
        public EmployeeStatus? Status { get; init; }
        public DateOnly? JoinedAfter { get; init; }
        public DateOnly? JoinedBefore { get; init; }
    }
}
