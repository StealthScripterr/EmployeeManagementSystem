using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;

namespace EmployeeManagementSystem.Application.Services;

public sealed class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentRequestDto request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Name is required.");

        // Simple uniqueness check (DB unique index is still recommended)
        var exists = await _departmentRepository.ExistsByNameAsync(request.Name, cancellationToken);
        if (exists)
            throw new InvalidOperationException("Department name already exists.");

        var department = new Department(request.Name, request.Description);
        await _departmentRepository.AddAsync(department, cancellationToken);

        return ToDto(department);
    }

    public async Task<DepartmentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dept = await _departmentRepository.GetByIdAsync(id, cancellationToken);
        return dept is null ? null : ToDto(dept);
    }

    public async Task<IReadOnlyList<DepartmentDto>> ListAsync(
        string? search,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize <= 0 || pageSize > 50) pageSize = 20;

        var list = await _departmentRepository.ListAsync(search, pageNumber, pageSize, cancellationToken);
        return list.Select(ToDto).ToList().AsReadOnly();
    }

    public async Task<DepartmentDto?> UpdateAsync(Guid id, UpdateDepartmentRequestDto request, CancellationToken cancellationToken = default)
    {
        var dept = await _departmentRepository.GetByIdAsync(id, cancellationToken);
        if (dept is null) return null;

        // Optional: uniqueness check if name changes
        if (!string.Equals(dept.Name, request.Name?.Trim(), StringComparison.Ordinal))
        {
            var exists = await _departmentRepository.ExistsByNameAsync(request.Name, cancellationToken);
            if (exists)
                throw new InvalidOperationException("Department name already exists.");
        }

        dept.Update(request.Name, request.Description);
        await _departmentRepository.UpdateAsync(dept, cancellationToken);

        return ToDto(dept);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dept = await _departmentRepository.GetByIdAsync(id, cancellationToken);
        if (dept is null) return false;

        await _departmentRepository.DeleteAsync(dept, cancellationToken);
        return true;
    }

    private static DepartmentDto ToDto(Department d) => new()
    {
        Id = d.Id,
        Name = d.Name,
        Description = d.Description
    };
}
