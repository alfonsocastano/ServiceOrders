using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
