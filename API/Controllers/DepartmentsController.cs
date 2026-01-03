using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    [Authorize(Policy = Policies.CanManageDepartments)]
    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create(
        [FromBody] CreateDepartmentRequestDto request,
        CancellationToken cancellationToken)
    {
        var created = await _departmentService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [Authorize(Policy = Policies.CanViewDepartments)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DepartmentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dept = await _departmentService.GetByIdAsync(id, cancellationToken);
        if (dept is null) return NotFound();
        return Ok(dept);
    }
    [Authorize(Policy = Policies.CanViewDepartments)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DepartmentDto>>> List(
        [FromQuery] string? search,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _departmentService.ListAsync(search, pageNumber, pageSize, cancellationToken);
        return Ok(result);
    }
    [Authorize(Policy = Policies.CanManageDepartments)]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<DepartmentDto>> Update(
        Guid id,
        [FromBody] UpdateDepartmentRequestDto request,
        CancellationToken cancellationToken)
    {
        var updated = await _departmentService.UpdateAsync(id, request, cancellationToken);
        if (updated is null) return NotFound();
        return Ok(updated);
    }
    [Authorize(Policy = Policies.CanManageDepartments)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var ok = await _departmentService.DeleteAsync(id, cancellationToken);
        return ok ? NoContent() : NotFound();
    }
}
