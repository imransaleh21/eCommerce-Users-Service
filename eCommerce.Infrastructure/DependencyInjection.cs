using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Adds the infrastructure services to the specified IServiceCollection. This add the infrastructure services to Dependency Injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add infrastructure services here
        services.AddScoped<IUsersRepository, UsersRepository>();
        // Add DapperDbContext as a scoped service to the DI container, allowing it to be injected into other services or controllers that require database access.
        services.AddScoped<DapperDbContext>();
        return services;
    }
}