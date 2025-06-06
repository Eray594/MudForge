using Blazored.LocalStorage;
using MudBlazor;
using Microsoft.JSInterop;

namespace MudForge.WebAssembly.Theming;

/// <summary>
/// Manages the application's theme settings, including dark mode state and local storage persistence.
/// </summary>
public class MudThemeService
{
    private readonly MudThemeServiceConfiguration _configuration;
    private readonly string _localStorageKey;
    private readonly ILocalStorageService _localStorageService;
    private readonly IJSRuntime _jsRuntime;

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
    /// Creates a new instance of the <see cref="MudThemeService"/> using local storage, configuration, and JS runtime.
    /// </summary>
    /// <param name="localStorageService">Service for accessing browser local storage.</param>
    /// <param name="configuration">Configuration options for the theme service.</param>
    /// <param name="jsRuntime">JavaScript runtime for interacting with browser APIs.</param>
    public MudThemeService(ILocalStorageService localStorageService, MudThemeServiceConfiguration configuration,
        IJSRuntime jsRuntime)
    {
        _localStorageService = localStorageService;
        _configuration = configuration;
        Theme = configuration.Theme;
        _jsRuntime = jsRuntime;
        _localStorageKey = configuration.LocalStorageKey;
    }

    /// <summary>
    /// Initializes the theme setting by checking local storage.
    /// If no value is found, falls back to the default configuration or system preference.
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
                IsDarkMode = _configuration.DefaultThemeMode switch
                {
                    MudDefaultThemeMode.Light => false,
                    MudDefaultThemeMode.Dark => true,
                    MudDefaultThemeMode.System => await GetSystemPreferenceAsync(),
                    _ => false
                };
            }
        }
        catch
        {
            // Fallback to light theme in case of any error accessing local storage
            IsDarkMode = false;
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

    /// <summary>
    /// Retrieves the system's preferred color scheme (dark mode) using JavaScript interop.
    /// If detection fails, defaults to light mode.
    /// </summary>
    private async Task<bool> GetSystemPreferenceAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>(
                "eval",
                "window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches"
            );
        }
        catch
        {
            return false;
        }
    }
}