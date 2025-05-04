<img height="80" width="80" src="https://github.com/user-attachments/assets/08bee777-7be0-4001-b8a2-05f75dd321c1" alt="Variant">

# MudForge 🔨
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![nuget](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/MudForge.WebAssembly)

MudForge is an **open-source library** designed to simplify **theming** in Blazor applications. Built on **MudBlazor**, it enables developers to quickly integrate a powerful and customizable theming system into their Blazor projects.


## 🎨 **Features**
- ✅ **Theming**: Simplified implementation of the MudBlazor theming system.
- ✅ **WebAssembly**: Full support for theming in **Blazor WebAssembly** applications using **`localStorage`** for theme persistence.
- ❌ **Server-Side** (Coming Soon): Server-side theming with **Cookies** for persistent theme preference.
- ❌ Localization (Coming Soon): Localization support for both WebAssembly and Server-Side Blazor applications.
---

> [!WARNING]  
> Before using MudForge, ensure that **MudBlazor** is successfully installed in your project. https://mudblazor.com/getting-started/installation

## 🧪 **Example**
The following example demonstrates how to toggle between Light and Dark Mode using MudThemeService.
When the user clicks the button, the theme is updated in real-time, and the preference is automatically saved to the browser's localStorage. On the next page reload or application restart, MudForge reads the saved preference and restores the selected theme before the UI renders — ensuring a consistent user experience.

https://github.com/user-attachments/assets/e150d0c7-2a23-4719-81aa-d3b20711ed91

---

## 📦 **Installation**
### **Using .NET CLI (WebAssembly)**
```bash
dotnet add package MudForge.WebAssembly
```
> ⚠️ **For Server Version**: The server-side version is **Coming Soon**.  
> At the moment, only **MudForge.WebAssembly** is available for integration.

### **Using Visual Studio/Rider**
1. Right-click your project in **Solution Explorer**.
2. Select **Manage NuGet Packages**.
3. Search for **MudForge.WebAssembly** and click **Install**.

---

## 👋 **Getting Started (WebAssembly)**

### **1. Theming Setup**
Add the following lines to Program.cs to configure MudForge's theming services:

```csharp
// Import the namespace for MudForge and WebAssembly
using MudForge.WebAssembly.Theming;

...

// Add the MudForge Theming Service
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    DefaultThemeMode = MudDefaultThemeMode.System, // Theme Mode if no localStorage was set
    LocalStorageKey = "isDarkMode", // Store the user's theme preference in localStorage
    Theme = new MudTheme() // Provide the MudBlazor theme configuration – in our case, the default
});

// Build the host and get the MudThemeService from DI
var host = builder.Build();
var mudThemeService = host.Services.GetRequiredService<MudThemeService>();

// Load the user's theme preference (Dark or Light Mode) from localStorage
await mudThemeService.LoadUserPreferenceAsync();

// Run the Blazor application
await host.RunAsync();
```

> [!NOTE]  
> The LocalStorageKey stores the user's selected theme (Dark or Light mode) in the **browser's localStorage**, ensuring that the theme persists across sessions.

## 🌓 MudDefaultThemeMode

`MudDefaultThemeMode` defines the behavior of the initial theme selection when no theme preference is stored in **localStorage**.

It controls which theme is automatically applied on the first visit (or when no saved user preference exists).

| Value | Behavior |
|:--|:--|
| **Light** | Always start in Light Mode. |
| **Dark** | Always start in Dark Mode. |
| **System** | Automatically detect the user's system/browser theme using JavaScript Interop. |

---

### **2. Configure Components**
Modify your components using the MudThemeService by adding the following code to App.razor or MainLayout.razor:

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

> [!NOTE]  
> It does not matter whether the MudBlazor components are placed in App.razor or MainLayout.razor, as long as the service specifies the configuration.

---

### **3. Toggle Between Light and Dark Mode** 🌞🌑
With the ToggleAsync method in **MudThemeService**, you can easily switch between **Light and Dark Mode**:

```razor
@inject MudThemeService ThemeService
<MudButton OnClick="ThemeService.ToggleAsync">Toggle Theme</MudButton>
```
> [!NOTE]  
> The selected theme is automatically stored in the **localStorage**, so the user’s preference is preserved even after a page reload or restart of the application.

---

## 🎯 **Conclusion**
MudForge provides a **simple yet powerful** way to implement theming in Blazor applications using MudBlazor. The library is **flexible, customizable**, and integrates **seamlessly** into existing Blazor projects. The theme preference is stored persistently in the **localStorage**, ensuring a consistent user experience across sessions.
