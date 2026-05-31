using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetByUsernameAsync(string username);
}
