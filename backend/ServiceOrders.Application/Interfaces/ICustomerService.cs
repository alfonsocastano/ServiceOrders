using ServiceOrders.Application.DTOs.Customers;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();

    Task<Customer?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateCustomerDto dto);

    Task UpdateAsync(UpdateCustomerDto dto);

    Task DeleteAsync(int id);
}
