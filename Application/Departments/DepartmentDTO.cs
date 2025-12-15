namespace EmployeeManagementSystem.Application.Departments;

public sealed class DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
