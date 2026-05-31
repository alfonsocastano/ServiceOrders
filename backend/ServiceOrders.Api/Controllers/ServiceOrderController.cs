using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Application.DTOs.Orders;
using ServiceOrders.Application.Interfaces;

namespace ServiceOrders.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/orders")]
public class ServiceOrderController : ControllerBase
{
    private readonly IServiceOrderService _service;

    public ServiceOrderController(
        IServiceOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Search(
        [FromQuery] ServiceOrderFilterDto filter)
    {
        return Ok(await _service.SearchAsync(filter));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateServiceOrderDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateServiceOrderDto dto)
    {
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpPatch("status")]
    public async Task<IActionResult> ChangeStatus(
        ChangeOrderStatusDto dto)
    {
        await _service.ChangeStatusAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}