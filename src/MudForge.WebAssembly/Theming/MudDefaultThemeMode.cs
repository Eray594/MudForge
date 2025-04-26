namespace MudForge.WebAssembly.Theming;

/// <summary>
/// Specifies the default theme mode to apply when no user preference is stored in local storage.
/// </summary>
public enum MudDefaultThemeMode
{
    /// <summary>
    /// Always use the light theme as the default.
    /// </summary>
    Light,

    /// <summary>
    /// Always use the dark theme as the default.
    /// </summary>
    Dark,

    /// <summary>
    /// Automatically use the theme based on the user's system or browser preference.
    /// </summary>
    System
}