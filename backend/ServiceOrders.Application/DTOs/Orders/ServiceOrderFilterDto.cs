namespace ServiceOrders.Application.DTOs.Orders;

public sealed class ServiceOrderFilterDto
{
    public int? Status { get; set; }

    public string? TechnicianName { get; set; }

    public string? TechnicianSpecialty { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerDocument { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
