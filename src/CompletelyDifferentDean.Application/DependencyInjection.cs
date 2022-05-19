using AutoMapper;
using CompletelyDifferentDean.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompletelyDifferentDean.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDisciplineService, DisciplineService>();

        return services;
    }
}
