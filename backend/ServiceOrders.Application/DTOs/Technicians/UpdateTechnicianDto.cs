namespace ServiceOrders.Application.DTOs.Technicians;

public sealed class UpdateTechnicianDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;
}
