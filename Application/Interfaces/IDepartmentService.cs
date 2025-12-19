using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Employees;

public interface IDepartmentService
{
    Task<DepartmentDto> CreateAsync(CreateDepartmentRequestDto request, CancellationToken cancellationToken = default);
    Task<DepartmentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DepartmentDto>> ListAsync(
        string? search,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<DepartmentDto?> UpdateAsync(Guid id, UpdateDepartmentRequestDto request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
