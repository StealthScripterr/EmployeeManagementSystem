using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IEmployeeManagementService
    {
        Task ChangeStatusAsync(
            Guid employeeId,
            EmployeeStatus newStatus,
            CancellationToken cancellationToken = default);
        Task CreateEmployeeAsync(CreateEmployeeRequestDto request,
        CancellationToken cancellationToken = default);
    }
}
