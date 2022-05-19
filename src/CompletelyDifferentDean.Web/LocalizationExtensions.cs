using CompletelyDifferentDean.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace CompletelyDifferentDean.Web;

internal static class LocalizationExtensions
{
    public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
            };

            options.DefaultRequestCulture = new RequestCulture("ru");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }

    public static IMvcBuilder AddDtoLocalization(this IMvcBuilder builder)
    {
        return builder.AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(DtoResources));
        });
    }
}
