Ja Bro, es macht absolut Sinn, **beide Versionen** (WebAssembly und Server) in **einer Datei zu dokumentieren**, solange du den Unterschied zwischen den beiden klar herausstellst und den Status des **"Coming Soon"** für den **Server-Teil** deutlich machst. Auf diese Weise bleibt die Dokumentation **zentralisiert**, und Benutzer müssen sich nicht durch mehrere Dateien wühlen.

### ✅ **Warum es Sinn macht, beides in einem File zu dokumentieren:**

1. **Zentralisierte Dokumentation**:
   - **Vereinheitlicht** die Erklärung für alle Features von **MudForge**, sowohl für **WebAssembly** als auch für den **Server**, in einer einzigen Datei.
   
2. **Vermeidung von Redundanz**:
   - Du kannst die **gemeinsamen Themen** (wie Konfigurationen, das Setup und den allgemeinen Ablauf) zusammenfassen und auf die Unterschiede zwischen WebAssembly und Server hinweisen, ohne den gleichen Inhalt mehrfach zu schreiben.

3. **Erweiterbarkeit**:
   - Wenn **MudForge.Server** verfügbar ist, kannst du den Abschnitt einfach **aktualisieren**, ohne mehrere Dokumentationsdateien zu pflegen. Der Platzhalter für "Coming Soon" kann leicht durch den **vollständigen Server-Abschnitt** ersetzt werden.

---

### 📚 **Wie du die Dokumentation strukturierst:**

#### 1. **Hauptthema: MudForge**
   - **Kurze Einführung** und **Features** für beide Versionen, die gemeinsam verwendet werden können.
   
#### 2. **Installation**
   - **Für WebAssembly**: `MudForge.WebAssembly` (wird installiert)
   - **Für Server**: Hinweis auf "Coming Soon"

#### 3. **Getting Started (Konfiguration)**
   - **Für WebAssembly**: Beispiel-Code für `MudThemeService` mit `localStorage`.
   - **Für Server**: Hinweis auf den zukünftigen `MudServerThemeService` mit `Cookies`.

#### 4. **Erweiterungen und Toggle**
   - Beschreibung, wie der **Light/Dark Mode** für beide Versionen (WebAssembly und Server) funktioniert.
   - **Für Server**: Hinweis auf die Verwendung von **Cookies** (für den Server) später.

#### 5. **Zukunft (Coming Soon)**
   - Ein klarer Hinweis, dass der **Server-Teil** bald verfügbar ist und momentan **`localStorage`** nur für **WebAssembly** verwendet wird.

---

### Beispielstruktur der **Dokumentation**:

```markdown
# MudForge 🔨
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![nuget](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/MudForge)

MudForge is an **open-source library** designed to simplify **theming** in Blazor applications. Built on **MudBlazor**, it enables developers to quickly integrate a powerful and customizable theming system into their Blazor projects.

## 🎨 **Features**
- ✅ **Theming**: Simplified implementation of the MudBlazor theming system.
- ❌ **Localization (Coming Soon)**: Provides easy-to-use services for managing multiple languages in Blazor applications.
- ✅ **WebAssembly Support**: Full support for theming with **`localStorage`**.
- ⚠️ **Server Support (Coming Soon)**: Server-side theming with **Cookies** for persistent theme preference.

---

> [!WARNING]  
> Before using MudForge, ensure that **MudBlazor** is successfully installed in your project. https://mudblazor.com/getting-started/installation#using-templates

## 📦 **Installation**

### **Using .NET CLI**
```bash
dotnet add package MudForge.WebAssembly
```
> ⚠️ **For Server Version**: The server-side version will be available soon.

### **Using Visual Studio/Rider**
1. Right-click your project in **Solution Explorer**.
2. Select **Manage NuGet Packages**.
3. Search for **MudForge.WebAssembly** and click **Install**.

---

## 👋 **Getting Started**

### **1. Theming Setup (WebAssembly)**

Add the following lines to `Program.cs` to configure MudForge's theming services for WebAssembly:

```csharp
using MudForge.WebAssembly.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add MudForge Theming Service for WebAssembly
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = true, // Default theme set to Dark Mode
    LocalStorageKey = "IsDarkMode", // Stores user preference in localStorage
    Theme = new MudTheme() // Provide MudBlazor theme configuration
});

await builder.Build().RunAsync();
```

> [!NOTE]  
> The `LocalStorageKey` stores the user's selected theme (Dark or Light mode) in the **browser's localStorage**, ensuring that the theme persists across sessions.

> ⚠️ **Server Version (Coming Soon)**: The server-side version will use **Cookies** for theme persistence.

---

### **2. Configure Components (WebAssembly)**

Modify your components using the `MudThemeService` by adding the following code to `App.razor` or `MainLayout.razor`:

```razor
@inject MudThemeService ThemeService

<MudThemeProvider Theme="ThemeService.Theme" @bind-IsDarkMode="ThemeService.IsDarkMode"/>
<MudDialogProvider/>
<MudSnackbarProvider/>

@code {
    protected override void OnInitialized()
        => ThemeService.OnThemeChanged += StateHasChanged;
}
```

This ensures that your components dynamically adapt to theme changes managed by the MudThemeService.

---

### **3. Toggle Between Light and Dark Mode** 🌞🌑
You can easily switch between **Light and Dark Mode** using the `ToggleAsync` method in **MudThemeService**:

```razor
@inject MudThemeService ThemeService
<MudButton OnClick="ThemeService.ToggleAsync">Toggle Theme</MudButton>
```

> [!NOTE]  
> The selected theme is automatically stored in **localStorage**, so the user’s preference is preserved even after a page reload or restart of the application.

---

### **4. Server-Side Theme Setup (Coming Soon)**

> ⚠️ **Server-side theme management** will be available soon.  
> It will use **Cookies** to persist the theme across sessions, instead of `localStorage`.

To set it up, the **`MudServerThemeService`** will be used for managing themes based on **Cookies**.

```csharp
using MudForge.Server.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add MudForge Theming Service for Server (Coming Soon)
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = true, // Default theme set to Dark Mode
    LocalStorageKey = "IsDarkMode", // Future use of Cookies instead
    Theme = new MudTheme() // Provide MudBlazor theme configuration
});

await builder.Build().RunAsync();
```

> ⚠️ **Coming Soon**  
> The **Server-side implementation** will use **Cookies** to persist theme data across different sessions.

---

## 🎯 **Conclusion**

MudForge provides a **simple yet powerful** way to implement theming in **Blazor** applications using **MudBlazor**.  
The library is **flexible, customizable**, and integrates **seamlessly** into existing Blazor projects.

- **WebAssembly** version uses **localStorage** for theme persistence.
- **Server** version will use **Cookies** to persist theme data.  
- **Coming Soon!** Stay tuned for **MudForge.Server**.

---

## **Summary of Files:**

#### **MudThemeServiceConfiguration.cs**
- **Purpose**: Configuration class for MudThemeService that stores theme settings, local storage key, and dark mode status.
```csharp
public sealed record MudThemeServiceConfiguration
{
    public required MudTheme Theme { get; init; }
    public required string LocalStorageKey { get; init; }
    public required bool IsDarkMode { get; init; }
}
```

#### **MudThemeService.cs**
- **Purpose**: Manages theme settings, including dark mode state and local storage persistence. Initializes the theme from local storage.
```csharp
public class MudThemeService
{
    private readonly MudThemeServiceConfiguration _configuration;
    private readonly ILocalStorageService _localStorageService;
    private readonly string _localStorageKey;

    public MudThemeService(ILocalStorageService localStorageService, MudThemeServiceConfiguration configuration)
    {
        _localStorageService = localStorageService;
        _configuration = configuration;
        Theme = configuration.Theme;
        _localStorageKey = configuration.LocalStorageKey;
    }

    public bool IsDarkMode { get; set; }

    public async Task LoadUserPreferenceAsync()
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

    public async Task ToggleAsync()
    {
        IsDarkMode = !IsDarkMode;
        await _localStorageService.SetItemAsync(_localStorageKey, IsDarkMode);
    }
}
```

#### **MudThemeServiceExtension.cs**
- **Purpose**: Provides extension methods for registering MudThemeService in the DI container.
```csharp
public static class MudThemeServiceExtension
{
    public static IServiceCollection AddMudThemeServices(this IServiceCollection services, MudThemeServiceConfiguration configuration)
    {
        services.AddBlazoredLocalStorage();
        services.AddScoped<MudThemeService>(sp =>
            new MudThemeService(sp.GetRequiredService<ILocalStorageService>(), configuration));

        return services;
    }
}
```

#### **Program.cs**
- **Purpose**: Registers MudThemeService with the configured theme and sets up local storage and MudBlazor services.
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = true,
    LocalStorageKey = "IsDarkMode",
    Theme = new MudTheme()
});

var host = builder.Build();
var mudThemeService = host.Services.GetRequiredService<MudThemeService>();
await mudThemeService.LoadUserPreferenceAsync();
await builder.Build().RunAsync();
```

---

Diese Dokumentation stellt sicher, dass sowohl **WebAssembly als auch Server** klar behandelt werden, und enthält eine ordentliche Beschreibung für die **WebAssembly-Version**, mit der der Server-Teil als **Coming Soon** markiert ist. Sag Bescheid, wenn du noch etwas anpassen oder erweitern möchtest! 😊
