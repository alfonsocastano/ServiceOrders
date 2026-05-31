using Dapper;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Infrastructure.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _factory;

    public CustomerRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        const string sql = """
            SELECT
                id,
                full_name AS FullName,
                document_number AS DocumentNumber,
                address,
                phone,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS UpdatedAt
            FROM
            customers
            WHERE
            is_deleted = false
            ORDER BY
            id DESC
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryAsync<Customer>(sql);
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        const string sql = """
            SELECT
                id,
                full_name AS FullName,
                document_number AS DocumentNumber,
                address,
                phone,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS UpdatedAt
            FROM
            customers
            WHERE
            id = @Id 
            AND 
            is_deleted = false
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { id });
    }

    public async Task<Customer?> GetByDocumentAsync(string document)
    {
        const string sql = """
            SELECT
                id,
                full_name AS FullName,
                document_number AS DocumentNumber,
                address,
                phone,
                is_deleted AS IsDeleted,
                created_at AS CreatedAt,
                updated_at AS UpdatedAt
            FROM
            customers
            WHERE
            document_number = @document
            AND
            is_deleted = false
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { document });
    }

    public async Task<int> CreateAsync(Customer customer)
    {
        const string sql = """
            INSERT INTO customers (
            full_name,
            document_number,
            address,
            phone
            ) VALUES (
            @FullName,
            @DocumentNumber,
            @Address,
            @Phone
            ) RETURNING id
            """;

        using var connection = _factory.CreateConnection();

        return await connection.ExecuteScalarAsync<int>(sql, customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        const string sql = """
                UPDATE customers
                SET
                full_name = @FullName,
                document_number = @DocumentNumber,
                address = @Address,
                phone = @Phone,
                updated_at = CURRENT_TIMESTAMP
                WHERE id = @Id
                """;

        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(sql, customer);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = """
                UPDATE customers
                SET
                is_deleted = true,
                updated_at = CURRENT_TIMESTAMP
                WHERE id = @Id
                """;


        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(sql, new { id });
    }
}
