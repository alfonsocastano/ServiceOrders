using System.Text;
using Dapper;
using ServiceOrders.Application.DTOs.Orders;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Infrastructure.Repositories;

public sealed class ServiceOrderRepository : IServiceOrderRepository
{
    private readonly IDbConnectionFactory _factory;

    public ServiceOrderRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<ServiceOrderDto>> SearchAsync(
        ServiceOrderFilterDto filter)
    {
        var sql = new StringBuilder();

        sql.Append("""
        SELECT
            so.id,
            so.description,
            so.status,
            t.full_name AS TechnicianName,
            t.specialty AS TechnicianSpecialty,
            c.full_name AS CustomerName,
            c.document_number AS CustomerDocument,
            so.created_at AS CreatedAt
        FROM service_orders so
        INNER JOIN technicians t
            ON t.id = so.technician_id
        INNER JOIN customers c
            ON c.id = so.customer_id
        WHERE so.is_deleted = false
        """);

        var parameters = new DynamicParameters();

        if (filter.Status.HasValue)
        {
            sql.Append(" AND so.status = @Status");
            parameters.Add("Status", filter.Status);
        }

        if (!string.IsNullOrWhiteSpace(filter.TechnicianName))
        {
            sql.Append(" AND UPPER(t.full_name) LIKE UPPER(@TechnicianName)");
            parameters.Add("TechnicianName", $"%{filter.TechnicianName}%");
        }

        if (!string.IsNullOrWhiteSpace(filter.TechnicianSpecialty))
        {
            sql.Append(" AND UPPER(t.specialty) LIKE UPPER(@TechnicianSpecialty)");
            parameters.Add("TechnicianSpecialty", $"%{filter.TechnicianSpecialty}%");
        }

        if (!string.IsNullOrWhiteSpace(filter.CustomerName))
        {
            sql.Append(" AND UPPER(c.full_name) LIKE UPPER(@CustomerName)");
            parameters.Add("CustomerName", $"%{filter.CustomerName}%");
        }

        if (!string.IsNullOrWhiteSpace(filter.CustomerDocument))
        {
            sql.Append(" AND c.document_number = @CustomerDocument");
            parameters.Add("CustomerDocument", filter.CustomerDocument);
        }

        if (filter.StartDate.HasValue)
        {
            sql.Append(" AND so.created_at >= @StartDate");
            parameters.Add("StartDate", filter.StartDate);
        }

        if (filter.EndDate.HasValue)
        {
            sql.Append(" AND so.created_at <= @EndDate");
            parameters.Add("EndDate", filter.EndDate);
        }

        sql.Append(" ORDER BY so.id DESC");

        using var connection = _factory.CreateConnection();

        return await connection.QueryAsync<ServiceOrderDto>(
            sql.ToString(),
            parameters);
    }

    public async Task<ServiceOrder?> GetByIdAsync(int id)
    {
        using var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<ServiceOrder>(
            """
            SELECT
                id,
                description,
                status,
                technician_id AS TechnicianId,
                customer_id AS CustomerId,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS UpdatedAt
            FROM service_orders
            WHERE id=@id
            AND is_deleted=false
            """,
            new { id });
    }

    public async Task<int> CreateAsync(ServiceOrder order)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(
            """
            INSERT INTO service_orders
            (
                description,
                status,
                technician_id,
                customer_id
            )
            VALUES
            (
                @Description,
                @Status,
                @TechnicianId,
                @CustomerId
            )
            """,
            order);

        return await connection.ExecuteScalarAsync<int>(
            "SELECT MAX(id) FROM service_orders");
    }

    public async Task UpdateAsync(ServiceOrder order)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(
            """
            UPDATE service_orders
            SET
                description=@Description,
                technician_id=@TechnicianId,
                customer_id=@CustomerId,
                updated_at=CURRENT_TIMESTAMP
            WHERE id=@Id
            """,
            order);
    }

    public async Task ChangeStatusAsync(int id, int status)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(
            """
            UPDATE service_orders
            SET
                status=@status,
                updated_at=CURRENT_TIMESTAMP
            WHERE id=@id
            """,
            new { id, status });
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(
            """
            UPDATE service_orders
            SET is_deleted=true
            WHERE id=@id
            """,
            new { id });
    }

    public Task<IEnumerable<ServiceOrder>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
