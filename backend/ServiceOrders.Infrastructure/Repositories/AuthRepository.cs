using Dapper;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Domain.Entities;

namespace ServiceOrders.Infrastructure.Repositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly IDbConnectionFactory _factory;

    public AuthRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        const string sql = """
            SELECT
            id,
            username,
            password_hash AS "Password",
            full_name AS FullName
            FROM users
            WHERE username = @Username
            AND is_deleted = false
            """;

        using var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { username });
    }
}
