using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexDashboard.Styles;

/// <summary>
/// Provides CSS class styles for the Sidebar component.
/// </summary>
internal readonly record struct SidebarStyles
{
    private static readonly string _base = ElementClass.Empty()
        .Add("fixed")
        .Add("lg:relative")
        .Add("z-30")
        .Add("h-full")
        .Add("bg-background")
        .Add("border-r")
        .Add("border-divider")
        .Add("transition-all")
        .Add("duration-300")
        .Add("ease-in-out")
        .ToString();

    private static readonly string _header = ElementClass.Empty()
        .Add("flex")
        .Add("items-center")
        .Add("gap-3")
        .Add("px-6")
        .Add("py-5")
        .ToString();

    private static readonly string _logoContainer = ElementClass.Empty()
        .Add("w-8")
        .Add("h-8")
        .Add("bg-primary")
        .Add("rounded-lg")
        .Add("flex")
        .Add("items-center")
        .Add("justify-center")
        .Add("shrink-0")
        .ToString();

    private static readonly string _logoIcon = ElementClass.Empty()
        .Add("w-5")
        .Add("h-5")
        .Add("text-white")
        .ToString();

    private static readonly string _title = ElementClass.Empty()
        .Add("text-lg")
        .Add("font-semibold")
        .Add("text-foreground")
        .Add("whitespace-nowrap")
        .ToString();

    private static readonly string _nav = ElementClass.Empty()
        .Add("flex-1")
        .Add("px-4")
        .Add("py-6")
        .Add("space-y-1")
        .Add("overflow-y-auto")
        .ToString();

    private static readonly string _userSection = ElementClass.Empty()
        .Add("px-4")
        .Add("py-4")
        .Add("border-t")
        .Add("border-divider")
        .ToString();

    private static readonly string _userContainer = ElementClass.Empty()
        .Add("flex")
        .Add("items-center")
        .Add("gap-3")
        .ToString();

    private static readonly string _userInfo = ElementClass.Empty()
        .Add("flex-1")
        .Add("min-w-0")
        .ToString();

    private static readonly string _userName = ElementClass.Empty()
        .Add("text-sm")
        .Add("font-medium")
        .Add("text-foreground")
        .Add("truncate")
        .ToString();

    private static readonly string _userEmail = ElementClass.Empty()
        .Add("text-xs")
        .Add("text-default-500")
        .Add("truncate")
        .ToString();

    private static readonly string _content = ElementClass.Empty()
        .Add("flex")
        .Add("flex-col")
        .Add("h-full")
        .ToString();

    private static ElementClass GetMobileStyles(bool isOpen)
    {
        return ElementClass.Empty()
            .Add("translate-x-0", when: isOpen)
            .Add("-translate-x-full", when: !isOpen)
            .Add("w-64");
    }

    private static ElementClass GetDesktopStyles(bool isCollapsed)
    {
        return ElementClass.Empty()
            .Add("lg:translate-x-0")
            .Add("lg:w-20", when: isCollapsed)
            .Add("lg:w-64", when: !isCollapsed);
    }

    public static string GetStyles(bool isOpen, bool isCollapsed, string? additionalClass = null)
    {
        return ElementClass.Empty()
            .Add(_base)
            .Add(GetMobileStyles(isOpen))
            .Add(GetDesktopStyles(isCollapsed))
            .Add(additionalClass)
            .ToString();
    }

    public static string GetContentStyles() => _content;

    public static string GetHeaderStyles() => _header;

    public static string GetLogoContainerStyles() => _logoContainer;

    public static string GetLogoIconStyles() => _logoIcon;

    public static string GetTitleStyles() => _title;

    public static string GetNavStyles() => _nav;

    public static string GetUserSectionStyles() => _userSection;

    public static string GetUserContainerStyles() => _userContainer;

    public static string GetUserInfoStyles() => _userInfo;

    public static string GetUserNameStyles() => _userName;

    public static string GetUserEmailStyles() => _userEmail;
}
