# MauiThemeSample

A .NET MAUI mobile application demonstrating dynamic theming with 5 color themes using a modern MVVM architecture.

## Overview

This project showcases a robust theming system for cross-platform mobile applications built with .NET MAUI. It demonstrates:

- **Dynamic Theme System**: Switch between 5 pre-defined color themes at runtime
- **MVVM Pattern**: Clean separation of concerns using Community Toolkit MVVM
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection for service management
- **Persistent Themes**: User theme selection is saved and loaded on app startup
- **Resource Dictionary Merging**: Efficient theme switching using XAML resource dictionaries
- **Multi-Platform Support**: Runs on Android and iOS

## Features

- **5 Color Themes**: Light, Dark, Blue, Orange, and White themes
- **Dynamic Theme Switching**: Change themes at runtime with immediate UI updates
- **Persistent Theme Storage**: Themes are saved using MAUI Preferences API
- **MVVM Architecture**: Community Toolkit MVVM with source generators
- **Service-Oriented Design**: IThemeService for clean theme management
- **Navigation**: Tabbed shell navigation with Home, Profile, and Theme Selection pages
- **Observable Properties**: Automatic UI updates using @ObservableProperty attributes
- **Relay Commands**: Type-safe command implementation with @RelayCommand attributes

## Project Structure

```
MauiThemeSample/
├── Enums/
│   └── Theme.cs                    # Theme enumeration
├── Models/
│   └── ThemeModel.cs               # Theme model with ObservableProperty
├── Services/
│   ├── Contracts/
│   │   └── IThemeService.cs        # Theme service interface
│   └── Implementations/
│       └── ThemeService.cs         # Theme service implementation
├── ViewModels/
│   ├── BaseViewModel.cs            # Base class for all ViewModels
│   ├── HomePageViewModel.cs        # ViewModel for Home page
│   ├── ProfilePageViewModel.cs     # ViewModel for Profile page
│   └── ThemeSelectionPageViewModel.cs  # ViewModel for Theme Selection page
├── Views/
│   ├── HomePage.xaml               # Home page UI
│   ├── HomePage.xaml.cs            # Home page code-behind
│   ├── ProfilePage.xaml            # Profile page UI
│   ├── ProfilePage.xaml.cs         # Profile page code-behind
│   ├── ThemeSelectionPage.xaml     # Theme selection page UI
│   └── ThemeSelectionPage.xaml.cs  # Theme selection page code-behind
├── Themes/
│   ├── light.xaml                  # Light theme resource dictionary
│   ├── dark.xaml                   # Dark theme resource dictionary
│   ├── blue.xaml                   # Blue theme resource dictionary
│   ├── orange.xaml                 # Orange theme resource dictionary
│   └── white.xaml                  # White theme resource dictionary
├── App.xaml                        # Application resources
├── App.xaml.cs                     # App startup with theme initialization
├── AppShell.xaml                   # Navigation shell with tab bar
├── AppShell.xaml.cs                # Shell code-behind
├── MauiProgram.cs                  # DI configuration and app startup
├── LICENSE                         # MIT License
└── README.md                       # This file
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2022, Visual Studio Code, or JetBrains Rider
- Android SDK (for Android builds)
- Xcode (for iOS builds on macOS)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build for all platforms
dotnet build

# Build for specific platform
dotnet build -f net10.0-android
dotnet build -f net10.0-ios
```

### Running the Application

```bash
# Run on Android emulator
dotnet run -f net10.0-android

# Run on iOS simulator
dotnet run -f net10.0-ios
```

## Architecture

### Theme System

The theming system is built around the `IThemeService` interface and `ThemeService` implementation:

```csharp
public interface IThemeService
{
    Theme CurrentTheme { get; }
    Task ChangeThemeAsync(Theme theme);
    Task LoadThemeAsync();
}
```

**How it works:**
1. Each theme has a corresponding XAML resource dictionary defining color resources
2. When a theme is selected, the appropriate resource dictionary is merged into the application resources
3. All UI elements bind to these color resources, so they update automatically
4. The selected theme is persisted using MAUI's Preferences API
5. On app startup, the saved theme is loaded and applied

### Resource Dictionary Structure

Each theme file (e.g., `light.xaml`) defines color resources:

```xml
<Color x:Key="PrimaryColor">#512BD4</Color>
<Color x:Key="SecondaryColor">#DFD8F7</Color>
<Color x:Key="PageBackgroundColor">#FFFFFF</Color>
<Color x:Key="TextColor">#333333</Color>
<!-- ... more colors ... -->
```

UI elements bind to these keys:
```xml
<Label Text="Home" TextColor="{StaticResource TextColor}" />
```

### Theme Selection

The `ThemeSelectionPageViewModel` manages available themes and handles user selection:

```csharp
[RelayCommand]
private async Task SelectTheme(ThemeModel theme)
{
    // Deselect all themes
    foreach (var t in Themes)
        t.IsSelected = false;

    // Select the chosen theme
    theme.IsSelected = true;

    // Apply the theme
    await _themeService.ChangeThemeAsync(theme.Theme);
}
```

## Available Themes

1. **Light Theme** - Neutral colors with dark text on light background
2. **Dark Theme** - Eye-friendly dark colors with light text
3. **Blue Theme** - Cool blue tones
4. **Orange Theme** - Warm orange tones
5. **White Theme** - Minimal contrast with neutral grays

## Dependency Injection

Services are registered in `MauiProgram.cs`:

```csharp
// Services
services.AddSingleton<IThemeService, ThemeService>();

// ViewModels
services.AddSingleton<HomePageViewModel>();
services.AddSingleton<ProfilePageViewModel>();
services.AddSingleton<ThemeSelectionPageViewModel>();

// Views
services.AddSingleton<AppShell>();
services.AddSingleton<HomePage>();
services.AddSingleton<ProfilePage>();
services.AddSingleton<ThemeSelectionPage>();

var serviceProvider = services.BuildServiceProvider();
ServiceProvider = serviceProvider;
```

## MVVM Implementation

### BaseViewModel

Provides common functionality for all ViewModels:

```csharp
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title = string.Empty;
}
```

### Page ViewModels

Each page has a corresponding ViewModel with its own logic and data bindings.

## Technologies Used

- **.NET MAUI**: Cross-platform mobile framework
- **Community Toolkit MVVM**: MVVM implementation with source generators
- **Microsoft.Extensions.DependencyInjection**: Dependency injection container
- **C# 13**: Latest language features

## Supported Platforms

- Android 21.0+
- iOS 15.0+

## License

MIT License - See LICENSE file for details

## Author

Preetanshu Mishra
