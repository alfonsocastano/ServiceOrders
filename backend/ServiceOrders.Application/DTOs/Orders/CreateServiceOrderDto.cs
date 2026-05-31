namespace ServiceOrders.Application.DTOs.Orders;

public sealed class CreateServiceOrderDto
{
    public string Description { get; set; } = string.Empty;

    public int TechnicianId { get; set; }

    public int CustomerId { get; set; }
}
