using ServiceOrders.Application.DTOs.Technicians;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Application.Services;

public sealed class TechnicianService : ITechnicianService
{
    private readonly ITechnicianRepository _repository;

    public TechnicianService(ITechnicianRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Technician>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Technician?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<int> CreateAsync(CreateTechnicianDto dto)
    {
        var technician = new Technician
        {
            FullName = dto.FullName,
            Phone = dto.Phone,
            Specialty = dto.Specialty
        };

        return await _repository.CreateAsync(technician);
    }

    public async Task UpdateAsync(UpdateTechnicianDto dto)
    {
        await _repository.UpdateAsync(new Technician
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Phone = dto.Phone,
            Specialty = dto.Specialty
        });
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
