using MudBlazor;

namespace ThemeExample;

public static class Resources
{
    public const bool IsDarkMode = true;
    public const string LocalStorageKey = "IsDarkmode";

    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight
        {
            //Standard colors
            Primary = "#2997FF",
            PrimaryLighten = "#2073C2",
            PrimaryDarken = "#2073C2",
            PrimaryContrastText = "#FAFAFA",
        },

        PaletteDark = new PaletteDark
        {
            //Body background
            Background = "#000000",

            //Standard colors
            Primary = "#2997FF",
            PrimaryLighten = "#2073C2",
            PrimaryDarken = "#2073C2",
            PrimaryContrastText = "#FAFAFA",
        },
    };
}