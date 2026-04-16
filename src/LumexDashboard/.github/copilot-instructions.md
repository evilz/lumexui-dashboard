# GitHub Copilot Instructions

## Project Overview

This is a **Blazor** dashboard application using **.NET 10** with **C# preview** features. It consists of four projects:

- **LumexDashboard** — ASP.NET Core server host with Interactive Server + WebAssembly render modes (Blazor Auto)
- **LumexDashboard.Client** — Blazor WebAssembly client for the server-hosted app
- **Culturae.UI.Shared** — Razor class library for reusable UI components shared across projects
- **Culturae.Client** — Standalone Blazor WASM SPA (pages, layout, and services only)
- **Culturae.API** — ASP.NET Core REST API backend (data layer, business logic, and HTTP endpoints)

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

## Backend (Culturae.API)

### Architecture

The API follows a layered architecture: **Controller → Service → Repository (Unit of Work) → EF Core DbContext**.

- **Controllers** (`Controllers/`) — Thin HTTP layer; validate input and delegate to services
- **Services** (`Services/`) — Business logic; each service has a corresponding interface (e.g., `IProjectService` / `ProjectService`)
- **Repositories** (`Repositories/`) — Data access via EF Core; each repository has a corresponding interface (e.g., `IProjectRepository` / `ProjectRepository`)
- **Unit of Work** (`Repositories/IUnitOfWork.cs` / `UnitOfWork.cs`) — Coordinates repository access and `SaveChangesAsync()`
- **Entities** (`Entities/`) — EF Core domain models
- **DTOs** (`DTOs/`) — Record types used for API responses (no direct entity exposure)
- **Data** (`Data/AppDbContext.cs`) — EF Core DbContext (currently uses in-memory database with seed data)

### Conventions

- **Every service and repository must have an interface** (e.g., `IMyService` / `MyService`) to enable unit testing and DI
- Register services as `Scoped` in `Program.cs`
- Use record types for DTOs
- Pagination uses a generic `PagedResult<T>` record
- CORS is configured to allow the Culturae.Client origins (`http://localhost:5160`, `https://localhost:7165`)
- The API exposes OpenAPI/Swagger in development

### Running

- Default URL: `http://localhost:5256`
- Docker support via `Dockerfile` (multi-stage build, ports 8080/8081)

## Key Patterns

- Responsive rendering uses custom wrapper components (`DesktopOnly`, `MobileTablet`, `SmallUp`, `MobileOverlay`) that apply Tailwind responsive prefixes
- Theme switching uses JS interop with `localStorage` and CSS class toggling on the `<html>` element
- `BlazorDisableThrowNavigationException` is set to `true` in all projects
