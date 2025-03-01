using MudBlazor;

namespace MudForge.Example;

public static class Resources
{
    public const bool IsDarkMode = true;
    public const string LocalStorageKey = "IsDarkmode";
    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight
        {
            //Body background
            Background = "#FFFFFF",

            //Standard colors
            Primary = "#18181B",
            PrimaryLighten = "#2D2D2F",
            PrimaryDarken = "#2D2D2F",
            PrimaryContrastText = "#FFFFFF",

            Secondary = "#FAFAFA",
            SecondaryLighten = "#F4F4F5",
            SecondaryDarken = "#F4F4F5",
            SecondaryContrastText = "#000000",
            
            Tertiary = "#22A6B3",
            TertiaryLighten = "#56B8C3",
            TertiaryDarken = "#56B8C3",
            TertiaryContrastText = "#E7ECF0",


            Success = "#3cb371",
            SuccessLighten = "#339B61",
            SuccessDarken = "#339B61",
            SuccessContrastText = "#FFFFFF",

            Warning = "#FE9700",
            WarningLighten = "#FFB74D",
            WarningDarken = "#E65100",
            WarningContrastText = "#FFFFFF",

            Error = "#F44336",
            ErrorLighten = "#F66055",
            ErrorDarken = "#C62828",
            ErrorContrastText = "#FFFFFF",

            Info = "#2196F3",
            InfoLighten = "#90CAF9",
            InfoDarken = "#0D47A1",
            InfoContrastText = "#FFFFFF",

            Dark = "#27292F",
            DarkLighten = "#212121",
            DarkDarken = "#000000",
            DarkContrastText = "#FFFFFF",

            //Shades
            White = "#FFFFFF",
            Black = "#000000",

            //Appbar
            AppbarBackground = "#FFFFFF",
            AppbarText = "#000000",

            //Drawer
            DrawerBackground = "#FFFFFF",
            DrawerIcon = "#616161ff",
            DrawerText = "#424242ff",

            //Surface
            Surface = "#FFFFFF",

            //Text
            TextPrimary = "#27272a",
            TextSecondary = "#52525b",
            TextDisabled = "#00000060",

            //Divider
            Divider = "#f4f4f5",
            DividerLight = "#FAFAFA",

            //Lines & table lines
            LinesDefault = "#0000001e",
            LinesInputs = "#bdbdbdff",
            TableLines = "#e0e0e0ff",
            TableStriped = "#00000005",
            TableHover = "#0000000a",

            //Gray
            GrayDefault = "#f3f4f6",
            GrayLight = "#f3f4f6",
            GrayLighter = "#E0E0E0",
            GrayDarker = "#757575",
            GrayDark = "#616161",
            BackgroundGray = "#f5f5f5ff",

            //Action
            ActionDefault = "#52525b",
            ActionDisabled = "#00000042",
            ActionDisabledBackground = "#0000001e",

            //Overlay
            OverlayLight = "rgba(255,255,255,0.4980392156862745)",
            OverlayDark = "rgba(33,33,33,0.4980392156862745)",

            //Hover
            HoverOpacity = 0.06
        },

        PaletteDark = new PaletteDark
        {
            //Body background
            Background = "#020617",

            //Standard colors
            Primary = "#1D4ED8",
            PrimaryLighten = "#172554",
            PrimaryDarken = "#172554",
            PrimaryContrastText = "#FAFAFA",

            Secondary = "#FFFFFF",
            SecondaryLighten = "#D3D3D3",
            SecondaryDarken = "#D3D3D3",
            SecondaryContrastText = "#000000",

            Tertiary = "#22A6B3",
            TertiaryLighten = "#56B8C3",
            TertiaryDarken = "#56B8C3",
            TertiaryContrastText = "#E7ECF0",

            Success = "#3cb371",
            SuccessLighten = "#81C784",
            SuccessDarken = "#206e42",
            SuccessContrastText = "#FFFFFF",

            Warning = "#FE9700",
            WarningLighten = "#FFB74D",
            WarningDarken = "#E65100",
            WarningContrastText = "#FFFFFF",

            Error = "#F44336",
            ErrorLighten = "#F66055",
            ErrorDarken = "#C62828",
            ErrorContrastText = "#FFFFFF",

            Info = "#2196F3",
            InfoLighten = "#90CAF9",
            InfoDarken = "#0D47A1",
            InfoContrastText = "#FFFFFF",

            Dark = "#0A0A0A",
            DarkLighten = "#0A0A0A",
            DarkDarken = "#000000",
            DarkContrastText = "#FFFFFF",

            //Shades
            White = "#FFFFFF",
            Black = "#000000",

            //Appbar
            AppbarBackground = "#252529",
            AppbarText = "#FFFFFF",


            //Drawer
            DrawerBackground = "#000000",
            DrawerIcon = "#FFFFFF",
            DrawerText = "#FFFFFF",

            //Surface
            Surface = "#18181B",

            //Text
            TextPrimary = "#FAFAFA",
            TextSecondary = "#9E9EA7",
            TextDisabled = "#00000060",

            //Divider
            Divider = "#27272A",
            DividerLight = "#FFFFFF",

            //Lines & table lines
            LinesDefault = "#FFFFFF",
            LinesInputs = "#FFFFFF",
            TableLines = "#e0e0e0ff",
            TableStriped = "#00000005",
            TableHover = "#0000000a",

            //Gray
            GrayDefault = "#101012",
            GrayLight = "#BDBDBD",
            GrayLighter = "#E0E0E0",
            GrayDarker = "#757575",
            GrayDark = "#616161",
            BackgroundGray = "#f5f5f5ff",

            //Action
            ActionDefault = Colors.Shades.White,
            ActionDisabled = "#00000042",
            ActionDisabledBackground = "#0000001e",

            //Overlay
            OverlayLight = "rgba(255,255,255,0.4980392156862745)",
            OverlayDark = "rgba(33,33,33,0.4980392156862745)",

            //Hover
            HoverOpacity = 0.1
        },

        #region Typography

        Typography = new Typography
        {
            Default = new DefaultTypography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "400",
                FontSize = "0.875rem",

                LetterSpacing = "0.01071em",
                TextTransform = "none"
            },
            H1 = new H1Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "4rem",

                LetterSpacing = "-0.01562em",
                TextTransform = "none"
            },
            H2 = new H2Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "3.5rem",

                LetterSpacing = "-0.00833em",
                TextTransform = "none"
            },
            H3 = new H3Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "3em",

                LetterSpacing = "0em",
                TextTransform = "none"
            },

            H4 = new H4Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "2.5rem",

                LetterSpacing = "0em",
                TextTransform = "none"
            },

            H5 = new H5Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "2rem",

                LetterSpacing = "0em",
                TextTransform = "none"
            },

            H6 = new H6Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "600",
                FontSize = "1.5rem",

                LetterSpacing = "0em",
                TextTransform = "none"
            },


            Subtitle1 = new Subtitle1Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "500",
                FontSize = "1rem"
            },


            Subtitle2 = new Subtitle2Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "450",
                FontSize = "0.825rem"
            },

            Body1 = new Body1Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "400",
                FontSize = "1rem"
            },

            Body2 = new Body2Typography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "400",
                FontSize = "0.825rem"
            },


            Button = new ButtonTypography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "500",
                FontSize = "1rem"
            },

            Caption = new CaptionTypography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "300",
                FontSize = "1rem"
            },

            Overline = new OverlineTypography()
            {
                FontFamily = new[] { "Poppins" },
                FontWeight = "200",
                FontSize = "1rem"
            }
        },

        #endregion

        #region LayoutProperties

        LayoutProperties = new LayoutProperties
        {
            DrawerWidthLeft = "250px",
            DrawerWidthRight = "250px",
            DrawerMiniWidthLeft = "56px",
            DrawerMiniWidthRight = "56px",
            AppbarHeight = "64px",
            DefaultBorderRadius = "4px"
        },

        #endregion

        #region ZIndex

        ZIndex = new ZIndex
        {
            Drawer = 1100,
            Popover = 1200,
            AppBar = 1300,
            Dialog = 1400,
            Snackbar = 1500,
            Tooltip = 1600
        }

        #endregion
    };
}