namespace LumexDashboard.Client.Services;

public class AppStateService
{
    public event Action? OnChange;
    public event Action<ToastMessage>? OnToast;

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

    // Toast methods
    public void ShowToast(string title, string message, ToastType type = ToastType.Info) 
        => OnToast?.Invoke(new ToastMessage(title, message, type));
    
    public void ShowSuccess(string title, string message) 
        => ShowToast(title, message, ToastType.Success);
    
    public void ShowError(string title, string message) 
        => ShowToast(title, message, ToastType.Error);
    
    public void ShowWarning(string title, string message) 
        => ShowToast(title, message, ToastType.Warning);
    
    public void ShowInfo(string title, string message) 
        => ShowToast(title, message, ToastType.Info);

    private void NotifyStateChanged() => OnChange?.Invoke();
}

public record ToastMessage(string Title, string Message, ToastType Type);

public enum ToastType { Info, Success, Warning, Error }
