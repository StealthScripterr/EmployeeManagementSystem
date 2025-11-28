namespace EmployeeManagementSystem.Application.Employees
{
    public interface IEmployeeCreateService
    {
        public Task<EmployeeDto> CreateEmployeeAsync(
            CreateEmployeeRequestDto createEmployeeRequestDto,
            CancellationToken cancellationToken = default);
    }
}
