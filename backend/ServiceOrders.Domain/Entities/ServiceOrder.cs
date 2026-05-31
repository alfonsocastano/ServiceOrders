using ServiceOrders.Domain.Common;
using ServiceOrders.Domain.Enums;

namespace ServiceOrders.Domain.Entities;

public class ServiceOrder : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public ServiceOrderStatus Status { get; set; }

    public int TechnicianId { get; set; }

    public int CustomerId { get; set; }
}
