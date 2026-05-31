using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Application.DTOs.Technicians;
using ServiceOrders.Application.Interfaces;

namespace ServiceOrders.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/technicians")]
public class TechnicianController : ControllerBase
{
    private readonly ITechnicianService _service;

    public TechnicianController(ITechnicianService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateTechnicianDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTechnicianDto dto)
    {
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}