using Microsoft.Extensions.DependencyInjection;
using ServiceOrders.Application.Interfaces;
using ServiceOrders.Application.Services;
using ServiceOrders.Infrastructure.Persistence;
using ServiceOrders.Infrastructure.Repositories;
using ServiceOrders.Infrastructure.Security;

namespace ServiceOrders.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IAuthRepository, AuthRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<ITechnicianRepository, TechnicianRepository>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<ICustomerService, CustomerService>();

        services.AddScoped<ITechnicianService, TechnicianService>();

        services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();

        services.AddScoped<IServiceOrderService, ServiceOrderService>();

        return services;
    }
}
