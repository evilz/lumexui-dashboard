namespace LumexDashboard.Services;

public class AppStateService
{
    public event Action? OnChange;

    // Sidebar state
    private bool _sidebarCollapsed = false;
    public bool SidebarCollapsed
    {
        get => _sidebarCollapsed;
        set
        {
            if (_sidebarCollapsed != value)
            {
                _sidebarCollapsed = value;
                NotifyStateChanged();
            }
        }
    }

    private bool _sidebarOpen = false;
    public bool SidebarOpen
    {
        get => _sidebarOpen;
        set
        {
            if (_sidebarOpen != value)
            {
                _sidebarOpen = value;
                NotifyStateChanged();
            }
        }
    }

    // Command palette state
    private bool _commandPaletteOpen = false;
    public bool CommandPaletteOpen
    {
        get => _commandPaletteOpen;
        set
        {
            if (_commandPaletteOpen != value)
            {
                _commandPaletteOpen = value;
                NotifyStateChanged();
            }
        }
    }

    // Theme state
    private string _themeMode = "system";
    public string ThemeMode
    {
        get => _themeMode;
        set
        {
            if (_themeMode != value)
            {
                _themeMode = value;
                NotifyStateChanged();
            }
        }
    }

    private string _themeColor = "blue";
    public string ThemeColor
    {
        get => _themeColor;
        set
        {
            if (_themeColor != value)
            {
                _themeColor = value;
                NotifyStateChanged();
            }
        }
    }

    public void ToggleSidebar() => SidebarOpen = !SidebarOpen;
    public void ToggleSidebarCollapse() => SidebarCollapsed = !SidebarCollapsed;
    public void OpenCommandPalette() => CommandPaletteOpen = true;
    public void CloseCommandPalette() => CommandPaletteOpen = false;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
