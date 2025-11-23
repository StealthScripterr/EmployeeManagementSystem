using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using EmployeeManagementSystem.Infrastructure.Persistence;

namespace EmployeeManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Employee>> SearchAsync(EmployeeSearchCriteria employeeSearchCriteria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
