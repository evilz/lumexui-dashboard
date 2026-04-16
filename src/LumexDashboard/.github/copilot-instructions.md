# GitHub Copilot Instructions

## Project Overview

This is a **Blazor** dashboard application using **.NET 10** with **C# preview** features. It consists of four projects:

- **LumexDashboard** — ASP.NET Core server host with Interactive Server + WebAssembly render modes (Blazor Auto)
- **LumexDashboard.Client** — Blazor WebAssembly client for the server-hosted app
- **Culturae.UI.Shared** — Razor class library for reusable UI components shared across projects
- **Culturae.Client** — Standalone Blazor WASM SPA (pages, layout, and services only)

## Tech Stack

- .NET 10, C# 13+ (preview) with nullable enabled and implicit usings
- **LumexUI** component library (`LumexButton`, `LumexCard`, `LumexAvatar`, `LumexDivider`, `LumexThemeProvider`, etc.)
- **Blazor.Sonner** for toast notifications
- **Tailwind CSS v4** compiled with `@tailwindcss/cli`

## Coding Conventions

### C# / Razor

- Private fields use `_camelCase` prefix (e.g., `_isOpen`, `_searchQuery`)
- Component parameters use `[Parameter]` with PascalCase and XML doc comments
- Use `@inject` for dependency injection in Razor files
- Keep all component logic in `@code { }` blocks at the bottom of `.razor` files — no code-behind files
- Implement `IDisposable` when subscribing to state events (`OnChange += StateHasChanged` / `OnChange -= StateHasChanged`)
- Use C# preview features like semi-auto properties (`field` keyword) where appropriate

### State Management

- Centralized `AppStateService` (scoped) with the observer pattern (`event Action? OnChange`)
- No Flux/Redux — keep state simple and service-based

### Styling

- Use **Tailwind CSS v4** utility classes with LumexUI semantic color tokens (`bg-background`, `text-foreground`, `bg-content1`, `text-default-500`, `border-divider`, `bg-primary`, `text-success`, `text-warning`, `text-danger`)
- Define component styles in companion `*Styles.cs` files declared as `internal readonly record struct`
- Build Tailwind class strings using `ElementClass` from `LumexUI.Utilities` with `.Add("class", when: condition)` for conditional classes
- Use CSS custom properties for layout dimensions (`--sidebar-width`, `--topbar-height`, etc.)
- Icons are inline SVG — do not use an icon library

### Project Structure

```
Layout/            → Layout components (MainLayout, Sidebar, TopBar, NavMenu)
Pages/             → Routable @page components
Shared/            → Reusable non-layout components
Shared/Responsive/ → Responsive wrapper components using Tailwind breakpoints
Styles/            → C# style classes (*Styles.cs)
Services/          → Application services
wwwroot/           → Static assets
```

## Build

Tailwind CSS is compiled via:

```
npx @tailwindcss/cli -i wwwroot/app.css -o wwwroot/app.build.css --minify
```

## Component Placement & Reuse

1. **Prefer existing components** — Before creating anything new, check if a suitable component already exists in **LumexUI** (the NuGet package), the **LumexDashboard** server project, or **Culturae.UI.Shared**. Use it instead of duplicating.
2. **New reusable components go in `Culturae.UI.Shared`** — Any new component that doesn't already exist and could be reused should be created in the `Culturae.UI.Shared` Razor class library.
3. **Keep `Culturae.Client` minimal** — It should only contain pages (`Pages/`), layout scaffolding (`Layout/`), and app-specific services (`Services/`). No general-purpose UI components.
4. **Eliminate duplicates** — If a component is duplicated across projects, remove the duplicate and consolidate it into `Culturae.UI.Shared` (or use the LumexUI built-in if one exists).
5. **Component lookup order**: LumexUI (NuGet) → Culturae.UI.Shared → LumexDashboard → create new in Culturae.UI.Shared.

## Key Patterns

- Responsive rendering uses custom wrapper components (`DesktopOnly`, `MobileTablet`, `SmallUp`, `MobileOverlay`) that apply Tailwind responsive prefixes
- Theme switching uses JS interop with `localStorage` and CSS class toggling on the `<html>` element
- `BlazorDisableThrowNavigationException` is set to `true` in all projects
