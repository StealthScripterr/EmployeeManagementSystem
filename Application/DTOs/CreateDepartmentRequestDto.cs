namespace EmployeeManagementSystem.Application.DTOs;

public sealed class CreateDepartmentRequestDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
