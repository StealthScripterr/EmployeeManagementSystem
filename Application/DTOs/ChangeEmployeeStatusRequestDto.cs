using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.DTOs
{
    public sealed class ChangeEmployeeStatusRequestDto
    {
        public EmployeeStatus NewStatus { get; set; }
    }
}
