using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace CompletelyDifferentDean.Dto;

public static class DependencyInjection
{
    public static IServiceCollection AddDto(this IServiceCollection services)
    {
        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
