
using ServiceOrders.Domain.Common;

namespace ServiceOrders.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}
