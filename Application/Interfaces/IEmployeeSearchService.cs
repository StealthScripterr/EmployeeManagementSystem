using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IEmployeeSearchService
    {
        Task<IReadOnlyList<EmployeeDto>> SearchAsync(
                                            string? namePrefix,
                                            Guid? departmentId,
                                            EmployeeStatus? status,
                                            DateOnly? dateOfJoining,
                                            int pageNumber,
                                            int pageSize,
                                            CancellationToken cancellationToken = default);
    }
}
