using ServiceOrders.Application.DTOs.Orders;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;
public interface IServiceOrderRepository
{
    Task<IEnumerable<ServiceOrderDto>> SearchAsync(ServiceOrderFilterDto filter);

    Task<IEnumerable<ServiceOrder>> GetAllAsync();

    Task<ServiceOrder?> GetByIdAsync(int id);

    Task<int> CreateAsync(ServiceOrder order);

    Task UpdateAsync(ServiceOrder order);

    Task ChangeStatusAsync(int id, int status);

    Task DeleteAsync(int id);
}
