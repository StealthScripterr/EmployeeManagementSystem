using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Models;

namespace EmployeeManagementSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<Employee?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Employee>> GetAllAsync();
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Guid id);
        Task<IReadOnlyList<Employee>> SearchAsync(EmployeeSearchCriteria employeeSearchCriteria);
    }
}
