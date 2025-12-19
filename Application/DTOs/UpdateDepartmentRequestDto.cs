namespace EmployeeManagementSystem.Application.DTOs;

public sealed class UpdateDepartmentRequestDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
