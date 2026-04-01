using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Adds the core services to the specified IServiceCollection. This add the core services to Dependency Injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Add core services here
        services.AddScoped<IUsersService, UsersService>();
        // Register all FluentValidation validators from Core assembly
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
