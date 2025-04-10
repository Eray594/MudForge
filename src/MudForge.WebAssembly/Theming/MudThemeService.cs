using Blazored.LocalStorage;
using MudBlazor;

namespace MudForge.Webassembly.Theming;

/// <summary>
/// Manages the application's theme settings, including dark mode state and local storage persistence.
/// </summary>
public class MudThemeService
{
    private readonly MudThemeServiceConfiguration _configuration;
    private readonly string _localStorageKey;
    private readonly ILocalStorageService _localStorageService;

    /// <summary>
    /// The MudTheme instance defining the application's visual style.
    /// </summary>
    public readonly MudTheme Theme;

    /// <summary>
    /// Indicates whether the current theme is in dark mode.
    /// </summary>
    public bool IsDarkMode { get; set; }

    /// <summary>
    /// Gets the currently active color palette based on the theme mode.
    /// </summary>
    public Palette CurrentPalette => IsDarkMode ? Theme.PaletteDark : Theme.PaletteLight;

    /// <summary>
    /// Event triggered whenever the theme mode changes.
    /// Can be used by UI components to refresh the layout accordingly.
    /// </summary>
    public event Action? OnThemeChanged;

    /// <summary>
    /// Creates a new instance of the <see cref="MudThemeService"/> using local storage and configuration.
    /// </summary>
    public MudThemeService(ILocalStorageService localStorageService, MudThemeServiceConfiguration configuration)
    {
        _localStorageService = localStorageService;
        _configuration = configuration;
        Theme = configuration.Theme;
        _localStorageKey = configuration.LocalStorageKey;
    }

    /// <summary>
    /// Initializes the theme setting by checking local storage.
    /// If no value is found, falls back to the default configuration.
    /// This method must be called once during application startup.
    /// </summary>
    public async Task LoadUserPreferenceAsync()
    {
        try
        {
            if (await _localStorageService.ContainKeyAsync(_localStorageKey))
            {
                IsDarkMode = await _localStorageService.GetItemAsync<bool>(_localStorageKey);
            }
            else
            {
                IsDarkMode = _configuration.IsDarkMode;
            }
        }
        catch
        {
            // Fallback to configured default in case of storage access error
            IsDarkMode = _configuration.IsDarkMode;
        }

        OnThemeChanged?.Invoke();
    }

    /// <summary>
    /// Toggles between dark and light theme modes and saves the preference in local storage.
    /// Notifies subscribers about the change.
    /// </summary>
    public async Task ToggleAsync()
    {
        IsDarkMode = !IsDarkMode;
        OnThemeChanged?.Invoke();
        await _localStorageService.SetItemAsync(_localStorageKey, IsDarkMode);
    }
}
