namespace EmployeeManagementSystem.Application.DTOs
{
    public sealed class EmployeeDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string? ContactNumber { get; init; }
        public string Status { get; init; } = default!; 
        public DateOnly DateOfJoining { get; init; }
        public string? DepartmentName { get; init; }
        public string? DesignationName { get; init; }
    }
}
