using ServiceOrders.Application.DTOs.Customers;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
=> _repository.GetAllAsync();

    public Task<Customer?> GetByIdAsync(int id)
    => _repository.GetByIdAsync(id);

    public async Task<int> CreateAsync(CreateCustomerDto dto)
    {
        var existing = await _repository.GetByDocumentAsync(dto.DocumentNumber);

        if (existing is not null)
            throw new Exception("Cliente ya existe");

        var customer = new Customer
        {
            FullName = dto.FullName,
            DocumentNumber = dto.DocumentNumber,
            Address = dto.Address,
            Phone = dto.Phone
        };

        return await _repository.CreateAsync(customer);
    }

    public async Task UpdateAsync(UpdateCustomerDto dto)
    {
        await _repository.UpdateAsync(new Customer
        {
            Id = dto.Id,
            FullName = dto.FullName,
            DocumentNumber = dto.DocumentNumber,
            Address = dto.Address,
            Phone = dto.Phone
        });
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
