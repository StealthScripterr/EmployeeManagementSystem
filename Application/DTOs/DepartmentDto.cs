namespace EmployeeManagementSystem.Application.DTOs;

public sealed class DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
