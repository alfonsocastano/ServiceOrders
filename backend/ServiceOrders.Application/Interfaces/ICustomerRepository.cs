using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();

    Task<Customer?> GetByIdAsync(int id);

    Task<Customer?> GetByDocumentAsync(string document);

    Task<int> CreateAsync(Customer customer);

    Task UpdateAsync(Customer customer);

    Task DeleteAsync(int id);
}
