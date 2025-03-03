# MudForge 🚀

MudForge is an **open-source library** designed to simplify **theming** in Blazor applications. Built on **MudBlazor**, it enables developers to quickly integrate a powerful and customizable theming system into their Blazor projects.

## 🎨 **Features**
- 🎭 **Theming**: Simplified implementation of the MudBlazor theming system.
- 🌍 **Localization (Coming Soon)**: Provides easy-to-use services for managing multiple languages in Blazor applications.

> ⚠️ **Important**: Before using MudForge, ensure that **MudBlazor** is successfully installed in your project.

---

## 📦 **Installation**

### **Using .NET CLI**
```bash
dotnet add package MudForge
```

### **Using Visual Studio/Rider**
1. 🖱️ Right-click your project in **Solution Explorer**.
2. 🛠️ Select **Manage NuGet Packages**.
3. 🔎 Search for **MudForge** and click **Install**.

---

## 🏗️ **Usage**

### **1. Theming Setup**
Add the following lines to `Program.cs` to configure MudForge's theming services:

```csharp
using MudForge.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 🎨 Add MudForge Theming Service
builder.Services.AddThemeServices(new ThemeServiceConfiguration
{
    IsDarkMode = true, // 🌙 Default theme set to Dark Mode
    LocalStorageKey = "theme_mode", // 💾 Stores user preference
    Theme = new MudTheme() // 🎭 Provide MudBlazor theme configuration
});

await builder.Build().RunAsync();
```

---

### **2. Add Components**
Add the following components to `App.razor` or `MainLayout.razor`:

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

> ℹ️ **Note:** It does not matter whether the MudBlazor components are placed in `App.razor` or `MainLayout.razor`, as long as the service specifies the configuration.

---

### **3. Toggle Between Light and Dark Mode** 🌞🌑
With the `ToggleAsync` method in **MudThemeService**, you can easily switch between **Light and Dark Mode**:

```razor
@inject MudThemeService ThemeService
<MudButton OnClick="ThemeService.ToggleAsync">Toggle Theme</MudButton>
```

---

## 🎯 **Conclusion**
MudForge provides a **simple yet powerful** way to implement theming in Blazor applications using MudBlazor. The library is **flexible, customizable**, and integrates **seamlessly** into existing Blazor projects.

