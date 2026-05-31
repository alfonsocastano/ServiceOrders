using ServiceOrders.Application.DTOs.Orders;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface IServiceOrderService
{
    Task<IEnumerable<ServiceOrderDto>> SearchAsync(ServiceOrderFilterDto filter);

    Task<ServiceOrder?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateServiceOrderDto dto);
       
    Task UpdateAsync(UpdateServiceOrderDto dto);

    Task ChangeStatusAsync(ChangeOrderStatusDto dto);
    
    Task DeleteAsync(int id);
}
