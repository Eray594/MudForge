using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace MudForge.Services.MudThemeService;

public static class MudThemeServiceExtension
{
    public static void AddMudThemeServices(
        this IServiceCollection services, MudThemeServiceConfiguration mudThemeServiceConfiguration)
    {
        services.AddBlazoredLocalStorage();
        services.AddScoped<MudThemeService>(x =>
        {
            var localStorage = x.GetService<ILocalStorageService>();

            return new MudThemeService(localStorage, mudThemeServiceConfiguration);
        });
    }
}