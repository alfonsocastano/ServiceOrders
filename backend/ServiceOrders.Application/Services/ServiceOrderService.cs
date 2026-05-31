using ServiceOrders.Application.DTOs.Orders;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;
using ServiceOrders.Domain.Enums;

namespace ServiceOrders.Application.Services;

public sealed class ServiceOrderService : IServiceOrderService
{
    private readonly IServiceOrderRepository _repository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ITechnicianRepository _technicianRepository;

    public ServiceOrderService(
    IServiceOrderRepository repository,
    ICustomerRepository customerRepository,
    ITechnicianRepository technicianRepository)
    {
        _repository = repository;
        _customerRepository = customerRepository;
        _technicianRepository = technicianRepository;
    }

    public Task<IEnumerable<ServiceOrderDto>> SearchAsync(
    ServiceOrderFilterDto filter)
    {
        return _repository.SearchAsync(filter);
    }

    public Task<ServiceOrder?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(CreateServiceOrderDto dto)
    {
        var customerId = dto.CustomerId;
        var customer =
        await _customerRepository.GetByIdAsync(customerId);

        if (customer is null)
            throw new Exception("Cliente no encontrado");

        var technicianId = dto.TechnicianId;
        var technician =
        await _technicianRepository.GetByIdAsync(technicianId);

        if (technician is null)
            throw new Exception("Técnico no encontrado");

        return await _repository.CreateAsync(
        new ServiceOrder
        {
            Description = dto.Description,
            CustomerId = customerId,
            TechnicianId = technicianId,
            Status = ServiceOrderStatus.Pending
        });
    }

    public async Task UpdateAsync(UpdateServiceOrderDto dto)
    {
        await _repository.UpdateAsync(
        new ServiceOrder
        {
            Id = dto.Id,
            Description = dto.Description,
            CustomerId = dto.CustomerId,
            TechnicianId = dto.TechnicianId
        });
    }

    public Task ChangeStatusAsync(ChangeOrderStatusDto dto)
    {
        return _repository.ChangeStatusAsync(
        dto.OrderId,
        dto.Status);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}
