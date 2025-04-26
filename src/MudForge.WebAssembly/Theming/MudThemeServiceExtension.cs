using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace MudForge.WebAssembly.Theming;

/// <summary>
/// Provides extension methods for registering the MudThemeService in the DI container.
/// </summary>
public static class MudThemeServiceExtension
{
    /// <summary>
    /// Adds the MudThemeService and its required dependencies to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection instance used for dependency injection.</param>
    /// <param name="configuration">The configuration settings that define the behavior of the MudThemeService.</param>
    /// <returns>The updated IServiceCollection instance.</returns>
    public static IServiceCollection AddMudThemeServices(
        this IServiceCollection services, MudThemeServiceConfiguration configuration)
    {
        // Register Blazored.LocalStorage to enable browser storage access
        services.AddBlazoredLocalStorage();
        
        // Register MudThemeService with injected dependencies: LocalStorageService, configuration, and JSRuntime
        services.AddScoped<MudThemeService>(sp =>
            new MudThemeService(
                sp.GetRequiredService<ILocalStorageService>(),
                configuration,
                sp.GetRequiredService<IJSRuntime>()
            ));

        return services;
    }
}