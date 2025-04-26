using MudBlazor;

namespace MudForge.WebAssembly.Theming;

/// <summary>
/// Configuration class for the MudThemeService. 
/// Defines theming settings such as the visual style, persistence key, and default behavior when no user preference is stored.
/// </summary>
public sealed record MudThemeServiceConfiguration
{
    /// <summary>
    /// The MudTheme instance that defines the application's visual appearance (colors, typography, etc.).
    /// </summary>
    public required MudTheme Theme { get; init; }

    /// <summary>
    /// The key used in local storage to persist the user's theme preference across sessions.
    /// </summary>
    public required string LocalStorageKey { get; init; }

    /// <summary>
    /// Defines the default theme mode (Light, Dark, or System) when no user preference exists.
    /// </summary>
    public required MudDefaultThemeMode DefaultThemeMode { get; init; }
}