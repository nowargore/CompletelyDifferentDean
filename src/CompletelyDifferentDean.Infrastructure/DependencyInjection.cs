using CompletelyDifferentDean.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompletelyDifferentDean.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //services.AddScoped<IDateTimeService, DateTimeService>();

        return services;
    }
}
