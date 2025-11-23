using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.Employees
{
    public interface IEmployeeSearchService
    {
        Task<IReadOnlyList<EmployeeDto>> SearchAsync(
                                            string? namePrefix,
                                            Guid? departmentId,
                                            EmployeeStatus? status,
                                            int pageNumber,
                                            int pageSize,
                                            CancellationToken cancellationToken = default);
    }
}
