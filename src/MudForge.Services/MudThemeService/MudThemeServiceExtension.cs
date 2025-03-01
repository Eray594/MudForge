using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace MudForge.Services.MudThemeService;

/// <summary>
/// Provides extension methods for registering the MudThemeService in the DI container.
/// </summary>
public static class MudThemeServiceExtension
{
    /// <summary>
    /// Adds MudThemeService and its dependencies to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection instance.</param>
    /// <param name="configuration">The configuration settings for the theme service.</param>
    public static IServiceCollection AddMudThemeServices(
        this IServiceCollection services, MudThemeServiceConfiguration configuration)
    {
        services.AddBlazoredLocalStorage();
        services.AddScoped<MudThemeService>(sp =>
            new MudThemeService(sp.GetRequiredService<ILocalStorageService>(), configuration));

        return services;
    }
}