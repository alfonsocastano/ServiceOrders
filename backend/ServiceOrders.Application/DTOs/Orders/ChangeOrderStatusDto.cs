namespace ServiceOrders.Application.DTOs.Orders;

public sealed class ChangeOrderStatusDto
{
    public int OrderId { get; set; }

    public int Status { get; set; }
}
