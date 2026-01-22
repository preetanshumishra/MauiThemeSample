# MauiThemeSample

A .NET MAUI demonstration of dynamic theming system with 5 distinct color schemes - Light, Dark, Blue, Orange, and White.

## Overview

This project showcases a production-ready theming system for .NET MAUI applications:
- **5 Color Themes** - Light, Dark, Blue, Orange, and White themes
- **Dynamic Switching** - Change themes at runtime with immediate UI updates
- **Persistent Storage** - Theme preference saved using Preferences API
- **Resource Dictionaries** - XAML-based theme resources for maintainability
- **IThemeService** - Clean service interface for theme management

## Tech Stack

- .NET 10.0
- .NET MAUI 10.0
- Community Toolkit MVVM 8.4.0
- Microsoft.Extensions.DependencyInjection 10.0.0

## Quick Start

```bash
# Build the project
dotnet build

# Run on iOS
dotnet run -f net10.0-ios

# Run on Android
dotnet run -f net10.0-android
```

## Key Features

- 5 pre-configured color themes with customizable palettes
- Real-time theme switching without restart
- Theme persistence across app sessions
- XAML resource dictionaries for theme resources
- IThemeService interface for decoupled theme management
- Clean MVVM integration with Community Toolkit

## License

MIT License - See LICENSE file for details.
