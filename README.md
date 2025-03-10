<img height="80" width="80" src="https://github.com/user-attachments/assets/08bee777-7be0-4001-b8a2-05f75dd321c1" alt="Variant">

# MudForge 🔨
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![nuget](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/MudForge)

MudForge is an **open-source library** designed to simplify **theming** in Blazor applications. Built on **MudBlazor**, it enables developers to quickly integrate a powerful and customizable theming system into their Blazor projects.


## 🎨 **Features**
- ✅**Theming**: Simplified implementation of the MudBlazor theming system.
- ❌**Localization (Coming Soon)**: Provides easy-to-use services for managing multiple languages in Blazor applications.

---

> [!WARNING]  
> Before using MudForge, ensure that **MudBlazor** is successfully installed in your project. https://mudblazor.com/getting-started/installation#using-templates

## 📦 **Installation**

### **Using .NET CLI**
```bash
dotnet add package MudForge
```

### **Using Visual Studio/Rider**
1. Right-click your project in **Solution Explorer**.
2. Select **Manage NuGet Packages**.
3. Search for **MudForge** and click **Install**.

---

## 👋 **Getting Started**

### **1. Theming Setup**
Add the following lines to `Program.cs` to configure MudForge's theming services:

```csharp
using MudForge.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add MudForge Theming Service
builder.Services.AddMudThemeServices(new MudThemeServiceConfiguration
{
    IsDarkMode = true, // Default theme set to Dark Mode
    LocalStorageKey = "theme_mode", // Stores user preference in localStorage
    Theme = new MudTheme() // Provide MudBlazor theme configuration
});

await builder.Build().RunAsync();
```
> [!NOTE]  
> The `LocalStorageKey` stores the user's selected theme (Dark or Light mode) in the **browser's localStorage**, ensuring that the theme persists across sessions.

---

### **2. Configure Components**
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

> [!NOTE]  
> It does not matter whether the MudBlazor components are placed in `App.razor` or `MainLayout.razor`, as long as the service specifies the configuration.

---

### **3. Toggle Between Light and Dark Mode** 🌞🌑
With the `ToggleAsync` method in **MudThemeService**, you can easily switch between **Light and Dark Mode**:

```razor
@inject MudThemeService ThemeService
<MudButton OnClick="ThemeService.ToggleAsync">Toggle Theme</MudButton>
```
> [!NOTE]  
> The selected theme is automatically stored in the **localStorage**, so the user’s preference is preserved even after a page reload or restart of the application.

---

## 🎯 **Conclusion**
MudForge provides a **simple yet powerful** way to implement theming in Blazor applications using MudBlazor. The library is **flexible, customizable**, and integrates **seamlessly** into existing Blazor projects. The theme preference is stored persistently in the **localStorage**, ensuring a consistent user experience across sessions.

