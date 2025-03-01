using Blazored.LocalStorage;
using MudBlazor;

namespace MudForge.Theming;

/// <summary>
/// Manages the application's theme settings, including dark mode state and local storage persistence.
/// </summary>
public class MudThemeService
{
    private readonly MudThemeServiceConfiguration _configuration;
    private readonly ILocalStorageService _localStorageService;
    private readonly string _localStorageKey;

    public readonly MudTheme Theme;

    public bool IsDarkMode;

    /// <summary>
    /// Event triggered when the theme mode changes.
    /// </summary>
    public event Action? OnThemeChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="MudThemeService"/> class.
    /// </summary>
    /// <param name="localStorageService">The local storage service for persisting theme settings.</param>
    /// <param name="configuration">The theme configuration settings.</param>
    public MudThemeService(ILocalStorageService localStorageService, MudThemeServiceConfiguration configuration)
    {
        _localStorageService = localStorageService;
        _configuration = configuration;
        Theme = configuration.Theme;
        _localStorageKey = configuration.LocalStorageKey;

        Task.Run(InitializeThemeAsync);
    }

    /// <summary>
    /// Gets the current palette based on the dark mode setting.
    /// </summary>
    public Palette CurrentPalette => IsDarkMode ? Theme.PaletteDark : Theme.PaletteLight;

    /// <summary>
    /// Toggles the dark mode setting and persists it in local storage.
    /// </summary>
    public async Task ToggleAsync()
    {
        IsDarkMode = !IsDarkMode;
        OnThemeChanged?.Invoke();
        await _localStorageService.SetItemAsync(_localStorageKey, IsDarkMode);
    }

    /// <summary>
    /// Initializes the theme setting by checking local storage or falling back to default configuration.
    /// </summary>
    private async Task InitializeThemeAsync()
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
            IsDarkMode = _configuration.IsDarkMode;
        }

        OnThemeChanged?.Invoke();
    }
}