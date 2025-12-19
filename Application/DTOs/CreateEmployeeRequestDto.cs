namespace EmployeeManagementSystem.Application.DTOs
{
    public class CreateEmployeeRequestDto
    {
        public string Name { get; init; } = default!;
        public string? ContactNumber { get; init; }
        public DateOnly? DateOfJoining { get; init; }
        public Guid DepartmentId { get; init; }
        public Guid DesignationId { get; init; }
    }
}
