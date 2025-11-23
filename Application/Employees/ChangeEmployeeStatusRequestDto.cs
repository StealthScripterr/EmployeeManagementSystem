using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.Employees
{
    public sealed class ChangeEmployeeStatusRequestDto
    {
        public EmployeeStatus NewStatus { get; set; }
    }
}
