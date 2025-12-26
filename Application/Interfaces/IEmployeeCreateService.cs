using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IEmployeeCreateService
    {
        public Task<EmployeeDto> CreateEmployeeAsync(
            CreateEmployeeRequestDto createEmployeeRequestDto,
            CancellationToken cancellationToken = default);
    }
}
