using System.Data;

namespace ServiceOrders.Application.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
