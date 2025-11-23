using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Models
{
    public sealed class EmployeeSearchCriteria
    {
        public string? Name { get; init; }
        public Guid? DepartmentId { get; init; }
        public EmployeeStatus? Status { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
