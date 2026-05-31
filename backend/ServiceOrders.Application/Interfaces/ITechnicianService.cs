using ServiceOrders.Application.DTOs.Technicians;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Interfaces;

public interface ITechnicianService
{
    Task<IEnumerable<Technician>> GetAllAsync();

    Task<Technician?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateTechnicianDto dto);

    Task UpdateAsync(UpdateTechnicianDto dto);

    Task DeleteAsync(int id);
}
