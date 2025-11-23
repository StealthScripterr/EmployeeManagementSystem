using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeManagementSystem.Application.Employees
{
    public class EmployeeSearchService : IEmployeeSearchService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeSearchService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IReadOnlyList<EmployeeDto>> SearchAsync(string? namePrefix, Guid? departmentId, EmployeeStatus? status, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                pageSize = 20;
            }

            var criteria = new EmployeeSearchCriteria
            {
                Name = namePrefix,
                DepartmentId = departmentId,
                Status = status,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var employees = await _employeeRepository.SearchAsync(criteria);

            var result = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                ContactNumber = e.ContactNumber,
                Status = e.Status.ToString(),
                DateOfJoining = e.DateOfJoining,
                DepartmentName = null,
                DesignationName = null
            }).ToList().AsReadOnly();

            return result;

        }
    }
}
