# LumexUI Dashboard

A modern, feature-rich admin dashboard built with [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) and [LumexUI](https://github.com/LumexUI/LumexUI) components. This project demonstrates best practices for building professional-grade dashboard applications using .NET 10 and Tailwind CSS.

[![Build and Deploy](https://github.com/evilz/lumexui-dashboard/actions/workflows/main_lumexui-dashboard.yml/badge.svg)](https://github.com/evilz/lumexui-dashboard/actions/workflows/main_lumexui-dashboard.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## 🌐 Live Demo

Experience the dashboard in action: **[Live Demo](https://lumexui-dashboard-fjf8f5axaddnhyf5.canadacentral-01.azurewebsites.net/)**

---

## ✨ Features

### Dashboard Components
- **📊 Interactive Cards** - Move goal trackers, cookie settings, subscription charts, and more
- **👥 User Management** - Complete CRUD interface with search, filtering, and pagination
- **💳 Payment Processing** - Transaction history, payment methods, and financial analytics
- **📁 File Management** - File browser with upload capabilities
- **📧 Mailbox** - Email interface with inbox, sent, and draft folders
- **📚 Courses** - Learning management system interface
- **✅ Task Management** - Kanban-style task organization
- **🎵 Music Player** - Media streaming interface
- **📺 Streaming** - Video content management
- **🔐 Authentication** - Login, signup, and OAuth integration pages
- **⚙️ Settings** - Profile, security, notifications, appearance, and billing management

### UI/UX Features
- **🌓 Dark/Light Theme** - Full theme switching with system preference detection
- **🎨 Customizable Colors** - Dynamic theme color selection
- **📱 Responsive Design** - Mobile-first approach with collapsible sidebar
- **⌨️ Command Palette** - Quick navigation with `⌘K` / `Ctrl+K`
- **🔔 Toast Notifications** - Rich notification system using Blazor.Sonner
- **🔍 Global Search** - Searchable command palette for quick actions

---

## 🏗️ Architecture

### Project Structure

```
src/LumexDashboard/
├── LumexDashboard/                 # Server project (Blazor Server)
│   ├── Components/
│   │   ├── App.razor               # Application root
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor    # Primary layout with sidebar
│   │   │   ├── NavMenu.razor       # Navigation menu component
│   │   │   └── ReconnectModal.razor # Connection status handler
│   │   ├── Pages/                  # Application pages
│   │   │   ├── Home.razor          # Dashboard overview
│   │   │   ├── Users.razor         # User management
│   │   │   ├── Payments.razor      # Payment history
│   │   │   ├── Settings.razor      # Application settings
│   │   │   └── ...                 # Other feature pages
│   │   └── Shared/                 # Reusable components
│   │       ├── CommandPalette.razor # Global search/command interface
│   │       ├── ThemeToggle.razor   # Dark/light mode switch
│   │       ├── StatsCard.razor     # Statistics display card
│   │       └── Responsive/         # Responsive helper components
│   ├── Program.cs                  # Application entry point
│   └── wwwroot/                    # Static assets
│       ├── app.css                 # Tailwind CSS source
│       └── app.build.css           # Compiled CSS
│
├── LumexDashboard.Client/          # Client project (Blazor WebAssembly)
│   ├── Pages/                      # Client-side pages
│   ├── Services/
│   │   └── AppStateService.cs      # Application state management
│   └── Program.cs                  # Client entry point
│
└── LumexDashboard.sln              # Solution file
```

### Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| **.NET** | 10.0 | Runtime & SDK |
| **Blazor** | Interactive Server + WebAssembly | UI framework with hybrid rendering |
| **LumexUI** | 2.0.1 | Component library |
| **Tailwind CSS** | 4.x | Utility-first styling |
| **Blazor.Sonner** | 0.0.2 | Toast notifications |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (for Tailwind CSS compilation)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/evilz/lumexui-dashboard.git
   cd lumexui-dashboard
   ```

2. **Install Node.js dependencies**
   ```bash
   cd src/LumexDashboard/LumexDashboard
   npm install
   ```

3. **Run the application**
   ```bash
   dotnet run --project src/LumexDashboard/LumexDashboard
   ```

4. **Open in browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Development

The Tailwind CSS is automatically compiled during the build process via MSBuild targets:

```xml
<Target Name="BuildTailwindCSS" BeforeTargets="Build">
    <Exec Command="npx @tailwindcss/cli -i wwwroot/app.css -o wwwroot/app.build.css --minify" />
</Target>
```

For watch mode during development:
```bash
npx @tailwindcss/cli -i wwwroot/app.css -o wwwroot/app.build.css --watch
```

---

## 🧩 Key Concepts

### 1. Hybrid Blazor Rendering

This dashboard uses **Interactive Auto** rendering mode, combining the benefits of both Server and WebAssembly:

```csharp
// Program.cs
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
```

### 2. Theme System

The application supports dynamic theming with:

- **Mode switching**: Light, Dark, and System preference
- **Persistent storage**: Theme preferences saved to localStorage
- **Flash prevention**: Theme applied before page render

```javascript
// Prevents flash of wrong theme on load
(function() {
    const savedTheme = localStorage.getItem('themeMode') || 'light';
    document.documentElement.classList.add(savedTheme);
})();
```

### 3. LumexUI Components

The dashboard leverages LumexUI's rich component library:

| Component | Usage |
|-----------|-------|
| `LumexCard` | Content containers with shadows |
| `LumexButton` | Various button styles and variants |
| `LumexAvatar` | User profile images with fallback |
| `LumexChip` | Status badges and tags |
| `LumexSwitch` | Toggle switches |
| `LumexDropdown` | Dropdown menus and selects |
| `LumexDivider` | Visual separators |
| `LumexCheckbox` | Checkbox inputs |
| `LumexThemeProvider` | Theme context provider |

### 4. Application State Management

Centralized state management using `AppStateService`:

```csharp
public class AppStateService
{
    public event Action? OnChange;
    
    // Sidebar state
    public bool SidebarCollapsed { get; set; }
    public bool SidebarOpen { get; set; }
    
    // Command palette state
    public bool CommandPaletteOpen { get; set; }
    
    // Theme state
    public string ThemeMode { get; set; }
    public string ThemeColor { get; set; }
}
```

### 5. Responsive Design

Built with mobile-first approach using Tailwind CSS breakpoints and custom responsive components:

```html
<!-- Desktop only -->
<DesktopOnly Display="flex">
    <button @onclick="ToggleSidebarCollapse">...</button>
</DesktopOnly>

<!-- Mobile/Tablet -->
<MobileTablet Display="block">
    <button @onclick="ToggleSidebar">...</button>
</MobileTablet>
```

### 6. Command Palette

Global search and quick actions with keyboard shortcuts:

- **Open**: `⌘K` (Mac) / `Ctrl+K` (Windows/Linux)
- **Navigate**: `↑` / `↓` arrow keys
- **Select**: `Enter`
- **Close**: `Escape`

---

## 📄 Pages Overview

| Page | Route | Description |
|------|-------|-------------|
| Dashboard | `/` | Overview with widgets, charts, and quick actions |
| Users | `/users` | User management with table, filters, and CRUD |
| Payments | `/payments` | Transaction history and payment analytics |
| Files | `/files` | File browser and management |
| Finance | `/finance` | Financial reports and metrics |
| Logs | `/logs` | System activity logs |
| Music | `/music` | Music player interface |
| Mailbox | `/mailbox` | Email client interface |
| Courses | `/courses` | Learning management |
| Tasks | `/tasks` | Task/project management |
| Streaming | `/streaming` | Video content management |
| Authentication | `/authentication` | Login, signup, OAuth pages |
| Settings | `/settings` | User and app preferences |

---

## 🎨 Customization

### Adding New Pages

1. Create a new `.razor` file in `Components/Pages/`
2. Add the `@page` directive with the route
3. Add navigation link in `NavMenu.razor`
4. Optionally add to command palette in `CommandPalette.razor`

### Styling

- **Global styles**: Edit `wwwroot/app.css`
- **Component styles**: Use scoped CSS files (`.razor.css`)
- **Tailwind utilities**: Apply directly in components

### Theme Colors

LumexUI theme colors are configured via CSS variables:
- `--lumex-primary`
- `--lumex-secondary`
- `--lumex-success`
- `--lumex-warning`
- `--lumex-danger`

---

## 🔧 Configuration

### Azure Deployment

The application is configured for Azure Web Apps deployment via GitHub Actions:

```yaml
# .github/workflows/main_lumexui-dashboard.yml
on:
  push:
    branches: [main]
  pull_request:
    branches: [main]
```

### Environment Settings

Development settings are in `appsettings.Development.json` and production settings in `appsettings.json`.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- [LumexUI](https://github.com/LumexUI/LumexUI) - Beautiful Blazor component library
- [Tailwind CSS](https://tailwindcss.com/) - Utility-first CSS framework
- [Blazor.Sonner](https://github.com/AhmedZaki99/Blazor.Sonner) - Toast notification library

---

## 📞 Support

For questions or support, please open an issue on GitHub or contact the maintainers.

---

**Made with ❤️ using Blazor and LumexUI**
