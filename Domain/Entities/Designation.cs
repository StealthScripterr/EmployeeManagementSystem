namespace EmployeeManagementSystem.Domain.Entities
{
    public class Designation
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
