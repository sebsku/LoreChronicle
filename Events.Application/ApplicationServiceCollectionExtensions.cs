using Events.Application.Database;
using Events.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IEventRepository, EventRepository>();
        return services;
    }
    
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        return services;
    }
}