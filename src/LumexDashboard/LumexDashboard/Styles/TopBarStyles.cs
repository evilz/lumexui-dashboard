using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexDashboard.Styles;

/// <summary>
/// Provides CSS class styles for the TopBar component.
/// </summary>
internal readonly record struct TopBarStyles
{
    private static readonly string _base = ElementClass.Empty()
        .Add("topbar")                // Uses --topbar-height CSS variable
        .Add("w-full")
        .Add("px-4")
        .Add("flex")
        .Add("items-center")
        .Add("justify-between")
        .Add("border-b")
        .Add("border-divider")
        .Add("bg-background")
        .Add("sticky")
        .Add("top-0")
        .Add("z-10")
        .ToString();

    private static readonly string _leftSection = ElementClass.Empty()
        .Add("flex")
        .Add("items-center")
        .Add("gap-3")
        .Add("flex-1")
        .ToString();

    private static readonly string _rightSection = ElementClass.Empty()
        .Add("flex")
        .Add("items-center")
        .Add("gap-2")
        .ToString();

    private static readonly string _iconButton = ElementClass.Empty()
        .Add("topbar-button")         // Uses --topbar-button-size CSS variable
        .Add("rounded-lg")
        .Add("hover:bg-default-100")
        .Add("transition-colors")
        .Add("flex")
        .Add("items-center")
        .Add("justify-center")
        .ToString();

    private static readonly string _iconButtonIcon = ElementClass.Empty()
        .Add("w-5")
        .Add("h-5")
        .Add("text-default-600")
        .ToString();

    private static readonly string _collapseIcon = ElementClass.Empty()
        .Add("w-5")
        .Add("h-5")
        .Add("text-default-600")
        .Add("transition-transform")
        .Add("duration-200")
        .ToString();

    private static readonly string _searchButton = ElementClass.Empty()
        .Add("topbar-search")         // Uses --topbar-search-width CSS variable
        .Add("flex")
        .Add("items-center")
        .Add("gap-2")
        .Add("px-4")
        .Add("py-2")
        .Add("rounded-lg")
        .Add("bg-default-100")
        .Add("hover:bg-default-200")
        .Add("transition-colors")
        .Add("text-sm")
        .Add("text-default-500")
        .ToString();

    private static readonly string _searchIcon = ElementClass.Empty()
        .Add("w-4")
        .Add("h-4")
        .Add("shrink-0")
        .ToString();

    private static readonly string _searchText = ElementClass.Empty()
        .Add("flex-1")
        .Add("text-left")
        .ToString();

    private static readonly string _searchKbd = ElementClass.Empty()
        .Add("hidden")
        .Add("md:inline-flex")
        .Add("items-center")
        .Add("gap-1")
        .Add("px-1.5")
        .Add("py-0.5")
        .Add("rounded")
        .Add("bg-default-200")
        .Add("text-xs")
        .ToString();

    private static readonly string _menuIcon = ElementClass.Empty()
        .Add("w-6")
        .Add("h-6")
        .Add("text-default-600")
        .ToString();

    public static string GetStyles(string? additionalClass = null)
    {
        return ElementClass.Empty()
            .Add(_base)
            .Add(additionalClass)
            .ToString();
    }

    public static string GetLeftSectionStyles() => _leftSection;

    public static string GetRightSectionStyles() => _rightSection;

    public static string GetIconButtonStyles() => _iconButton;

    public static string GetIconButtonIconStyles() => _iconButtonIcon;

    public static string GetCollapseIconStyles(bool isCollapsed)
    {
        return ElementClass.Empty()
            .Add(_collapseIcon)
            .Add("rotate-180", when: isCollapsed)
            .ToString();
    }

    public static string GetSearchButtonStyles() => _searchButton;

    public static string GetSearchIconStyles() => _searchIcon;

    public static string GetSearchTextStyles() => _searchText;

    public static string GetSearchKbdStyles() => _searchKbd;

    public static string GetMenuIconStyles() => _menuIcon;
}
