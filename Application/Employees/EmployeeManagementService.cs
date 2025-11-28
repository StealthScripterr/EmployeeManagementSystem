using System.Xml.Linq;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Interfaces;

namespace EmployeeManagementSystem.Application.Employees;

public sealed class EmployeeManagementService : IEmployeeManagementService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManagementService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task ChangeStatusAsync(
        Guid employeeId,
        EmployeeStatus newStatus,
        CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
        {
            throw new InvalidOperationException($"Employee {employeeId} not found.");
        }

        employee.ChangeStatus(newStatus);

        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task CreateEmployeeAsync(
        CreateEmployeeRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var employee = new Employee(
            request.Name,
            request.ContactNumber,
            request.DateOfJoining,
            request.DepartmentId,
            request.DesignationId
        );
        await _employeeRepository.AddAsync(employee);
    }
}
