using ServiceOrders.Domain.Common;

namespace ServiceOrders.Domain.Entities;

public class Technician : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;
}
