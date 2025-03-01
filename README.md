MudForge is an open-source library designed to simplify the implementation of **theming** in Blazor applications. Built on top of MudBlazor, it helps developers quickly integrate a robust and customizable theming system into their Blazor projects with minimal effort.

### **MudForge Features:**
- **Theming**: Simplifies the implementation of the MudBlazor theming system.
- **Localization (Soon)**: Offers easy-to-use localization services to manage different languages in your Blazor applications.

### **Installation:**
You can easily install **MudForge** via **NuGet**.

#### Using the .NET CLI:
```bash
dotnet add package MudForge
```

#### Using Visual Studio/Rider:
1. Right-click on your project in **Solution Explorer**.
2. Click **Manage NuGet Packages**.
3. Search for **MudForge** and click **Install**.

> [!NOTE]
> To perform these steps it is assumed that you have successfully installed MudBlazor on your project

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

#### 2. **Add Components:**
Add the following components to your `app.razor`:

> [!NOTE]
> It doesn't matter whether the MudBlazor components are stored in `app.razor` or in your `MainLayout.razor`. It is only important that the service specifies the configuration.

```razor
@inject MudThemeService ThemeService

<MudThemeProvider Theme="ThemeService.Theme" @bind-IsDarkMode="ThemeService.IsDarkMode"/>
<MudDialogProvider/>
<MudSnackbarProvider/>

....

@code {
    protected override void OnInitialized()
        => ThemeService.OnThemeChanged += StateHasChanged;
}
```

#### 3. **Change to Light/Dark Mode**  
With the `ToggleAsync` method in the **MudThemeService**, you can easily switch between Light & Dark Mode.

```razor
@inject MudThemeService ThemeService
<MudButton OnClick="ThemeService.ToggleAsync">Click Me!</MudButton>
```


This documentation provides a clear and comprehensive introduction to **MudForge**, including installation instructions, usage examples, configuration options, and contribution guidelines. It's perfect for developers looking to integrate theming into their Blazor applications quickly and efficiently.
