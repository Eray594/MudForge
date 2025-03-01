MudForge is an open-source library designed to simplify the implementation of **theming** in Blazor applications. Built on top of MudBlazor, it helps developers quickly integrate a robust and customizable theming system into their Blazor projects with minimal effort.

### **MudForge Features:**
- **Theming**: Simplifies the implementation of the MudBlazor theming system.
- **Light and Dark Mode**: Easily toggle between Light and Dark modes in your Blazor application.
- **Customizable Themes**: Supports theme customization to meet the design requirements of your application.
- **MudBlazor Support**: Fully integrates with MudBlazor to enhance the UI experience.

### **Installation:**
You can easily install **MudForge** via **NuGet**.

#### Using the .NET CLI:
```bash
dotnet add package MudForge
```

#### Using Visual Studio:
1. Right-click on your project in **Solution Explorer**.
2. Click **Manage NuGet Packages**.
3. Search for **MudForge** and click **Install**.

### **Usage:**
Once the package is installed, you can start using the theming services provided by MudForge.

#### 1. **Theming Setup:**
In your `Program.cs` file, add the following lines to configure MudForge's theming services:

```csharp
using MudForge.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add MudForge Theming Service
builder.Services.AddThemeServices(new ThemeServiceConfiguration
{
    IsDarkMode = true, // Set default theme to dark mode
    LocalStorageKey = "theme_mode", // Key to save user preferences
    Theme = new MudTheme() // Provide a MudBlazor theme configuration
});

await builder.Build().RunAsync();
```

#### 2. **Theme Switcher Example:**
To allow users to switch between Light and Dark mode, use the following button in your Blazor components:

```razor
@page "/"
@inject MudThemeService ThemeService

<MudStack Justify="Justify.Center" Row="true">
    <button @onclick="ThemeService.ToggleAsync" class="px-8 py-2 rounded-full bg-gradient-to-b from-blue-500 to-blue-600 text-white focus:ring-2 focus:ring-blue-400 hover:shadow-xl transition duration-200">
        Switch to @(ThemeService.IsDarkMode ? "Light Mode" : "Dark Mode")
    </button>
</MudStack>
```

#### 3. **MudBlazor Integration:**
MudForge works seamlessly with MudBlazor. You can use the MudBlazor components as usual, and MudForge services will handle the theming.

Example of a simple UI with MudBlazor and MudForge:

```razor
<MudThemeProvider Theme="ThemeService.Theme" @bind-IsDarkMode="ThemeService.Provider.IsDarkMode">
    <MudDialogProvider/>
    <MudSnackbarProvider/>
    <MudMainContent>
        @Body
    </MudMainContent>
</MudThemeProvider>
```

### **Configuration Options:**
#### **ThemeServiceConfiguration:**
- **IsDarkMode**: A boolean value that defines if the app starts in dark mode (default is `false`).
- **LocalStorageKey**: The key used to save the theme preference in `localStorage`.
- **Theme**: A `MudTheme` object that defines the visual theme settings for the app.

### **Contributing:**
MudForge is an open-source project, and contributions are welcome. If you'd like to contribute:

1. Open an issue or submit a pull request in the GitHub repository.
2. Follow the contributing guidelines and coding standards.

You can find the repository here: [MudForge GitHub Repository](https://github.com/Eray594/MudForge).

### **License:**
MudForge is licensed under the **MIT License**.

---

This documentation provides a clear and comprehensive introduction to **MudForge**, including installation instructions, usage examples, configuration options, and contribution guidelines. It's perfect for developers looking to integrate theming into their Blazor applications quickly and efficiently.
