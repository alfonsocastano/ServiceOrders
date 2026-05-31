using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface ITechnicianRepository
{
    Task<IEnumerable<Technician>> GetAllAsync();

    Task<Technician?> GetByIdAsync(int id);

    Task<int> CreateAsync(Technician technician);

    Task UpdateAsync(Technician technician);

    Task DeleteAsync(int id);
}
