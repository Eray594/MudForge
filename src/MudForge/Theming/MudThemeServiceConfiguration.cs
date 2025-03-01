using MudBlazor;

namespace MudForge.Theming;

/// <summary>
/// Configuration class for the MudThemeService. 
/// Stores theme settings, local storage key, and dark mode status.
/// </summary>
public sealed record MudThemeServiceConfiguration
{
    /// <summary>
    /// The MudTheme instance defining the application's visual style.
    /// </summary>
    public required MudTheme Theme { get; init; }

    /// <summary>
    /// The key used to store the dark mode preference in local storage.
    /// </summary>
    public required string LocalStorageKey { get; init; }

    /// <summary>
    /// The default dark mode setting when no preference is stored.
    /// </summary>
    public required bool IsDarkMode { get; init; }
}