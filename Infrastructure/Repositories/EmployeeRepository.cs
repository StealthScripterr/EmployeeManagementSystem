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
            _dbContext.Employees.Add(employee);
            return Task.FromResult(_dbContext.SaveChangesAsync());
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
            var query = _dbContext.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(employeeSearchCriteria.Name))
            {
                query = query.Where(e => e.Name.StartsWith(employeeSearchCriteria.Name));
            }

            if (employeeSearchCriteria.DepartmentId.HasValue)
            {
                query = query.Where(e => e.DepartmentId == employeeSearchCriteria.DepartmentId.Value);
            }
            if (employeeSearchCriteria.DateOfJoining.HasValue)
            {
                query = query.Where(e => e.DateOfJoining == employeeSearchCriteria.DateOfJoining.Value);
            }
            if (employeeSearchCriteria.Status.HasValue)
            {
                query = query.Where(e => e.Status == employeeSearchCriteria.Status.Value);
            }

            var skip = (employeeSearchCriteria.PageNumber - 1) * employeeSearchCriteria.PageSize;

            var employees = query.Skip(skip).Take(employeeSearchCriteria.PageSize).ToList();

            return Task.FromResult((IReadOnlyList<Employee>)employees);
        }

        public Task UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
