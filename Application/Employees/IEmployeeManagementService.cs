using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.Employees
{
    public interface IEmployeeManagementService
    {
        Task ChangeStatusAsync(
            Guid employeeId,
            EmployeeStatus newStatus,
            CancellationToken cancellationToken = default);
    }
}
