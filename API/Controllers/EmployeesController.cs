using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeSearchService _employeeSearchService;
        private readonly IEmployeeManagementService _employeeManagementService;
        public EmployeesController(IEmployeeSearchService employeeSearchService, IEmployeeManagementService employeeManagementService)
        {
            _employeeSearchService = employeeSearchService;
            _employeeManagementService = employeeManagementService;
        }

        [Authorize(Policy = Policies.CanViewEmployees)]
        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> SearchEmployees(
                                                                                [FromQuery] string? namePrefix,
                                                                                [FromQuery] Guid? departmentId,
                                                                                [FromQuery] EmployeeStatus? status,
                                                                                [FromQuery] DateOnly? dateOfJoining,
                                                                                [FromQuery] int pageNumber = 1,
                                                                                [FromQuery] int pageSize = 20,
                                                                                CancellationToken cancellationToken = default)
        {

            var employees = await _employeeSearchService.SearchAsync(
                                                                namePrefix,
                                                                departmentId,
                                                                status,
                                                                dateOfJoining,
                                                                pageNumber,
                                                                pageSize,
                                                                cancellationToken);
            return Ok(employees);
        }
        [Authorize(Policy = Policies.CanManageEmployees)]
        [HttpPut("{id:guid}/status")]
        public async Task<ActionResult> ChangeStatus(Guid id,
                                                    [FromBody] ChangeEmployeeStatusRequestDto request,
                                                    CancellationToken cancellationToken = default)
        {

            await _employeeManagementService.ChangeStatusAsync(id, request.NewStatus, cancellationToken);
            return NoContent();
        }

        [Authorize(Policy = Policies.CanManageEmployees)]
        [HttpPost("createEmployee")]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeRequestDto request,
                                                    CancellationToken cancellationToken = default)
        {
            await _employeeManagementService.CreateEmployeeAsync(request, cancellationToken);
            return NoContent();
        }

    }
}
