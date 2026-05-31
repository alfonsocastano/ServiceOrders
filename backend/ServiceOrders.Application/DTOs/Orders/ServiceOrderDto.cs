namespace ServiceOrders.Application.DTOs.Orders;

public sealed class ServiceOrderDto
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Status { get; set; }

    public string TechnicianName { get; set; } = string.Empty;

    public string TechnicianSpecialty { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerDocument { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
