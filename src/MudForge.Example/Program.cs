using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using MudForge.Example;
using MudForge.Services.MudThemeService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = Resources.IsDarkMode,
    LocalStorageKey = Resources.LocalStorageKey,
    Theme = Resources.Theme,
});

await builder.Build().RunAsync();