namespace EmployeeManagementSystem.Application.Departments;

public sealed class UpdateDepartmentRequestDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
