using Microsoft.Extensions.Configuration;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using ServiceOrders.Application.Interfaces;
using System.Data;

namespace ServiceOrders.Infrastructure.Persistence;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var provider = _configuration["DatabaseSettings:Provider"];

        return provider switch
        {
            "Oracle" => new OracleConnection(
                _configuration.GetConnectionString("Oracle")),

            _ => new NpgsqlConnection(
                _configuration.GetConnectionString("PostgreSql"))
        };
    }
}
