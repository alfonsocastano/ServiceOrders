using Dapper;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Infrastructure.Repositories;

public sealed class TechnicianRepository : ITechnicianRepository
{
    private readonly IDbConnectionFactory _factory;
    
        public TechnicianRepository(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

    public async Task<IEnumerable<Technician>> GetAllAsync()
    {
        const string sql = """
            SELECT
                id,
                full_name AS FullName,
                phone,
                specialty,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS updatedAt
            FROM
            technicians
            WHERE
            is_deleted = false
            ORDER BY
            id DESC
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryAsync<Technician>(sql);
    }

    public async Task<Technician?> GetByIdAsync(int id)
    {
        const string sql = """
            SELECT
                id,
                full_name AS FullName,
                phone,
                specialty,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS updatedAt
            FROM
            technicians
            WHERE
            id = @Id 
            AND 
            is_deleted = false
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Technician>(sql, new { id });
    }

    public async Task<int> CreateAsync(Technician technician)
    {
        const string sql = """
            INSERT INTO technicians 
            (
            full_name,
            phone,
            specialty
            ) VALUES 
            (
            @FullName,
            @Phone,
            @Specialty
            )
            RETURNING id
            """;

        using var connection = _factory.CreateConnection();

        return await connection.ExecuteScalarAsync<int>(sql, technician);
    }

    public async Task UpdateAsync(Technician technician)
    {
        const string sql = """
                UPDATE technicians 
                SET
                full_name=@FullName,
                phone=@Phone,
                specialty=@Specialty,
                updated_at=CURRENT_TIMESTAMP
                WHERE
                id=@Id
                """;

        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(sql, technician);
    }

    public async Task DeleteAsync(int id)
    {
                   const string sql = """
                UPDATE technicians
                SET
                is_deleted = true,
                updated_at = CURRENT_TIMESTAMP
                WHERE id = @Id
                """;

        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(sql, new { id });
    }
}
