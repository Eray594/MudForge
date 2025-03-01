using MudBlazor;

namespace MudForge.Services.MudThemeService;

public sealed class MudThemeServiceConfiguration
{
    public MudTheme Theme { get; init; }
    public string LocalStorageKey { get; init; }
    public bool IsDarkMode { get; init; }
}