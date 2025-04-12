using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using MudForge.WebAssembly.Example;
using MudForge.Webassembly.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = true,
    LocalStorageKey = "IsDarkMode",
    Theme = new MudTheme()
});
var host = builder.Build();
var mudThemeService = host.Services.GetRequiredService<MudThemeService>();
await mudThemeService.LoadUserPreferenceAsync();

await host.RunAsync();