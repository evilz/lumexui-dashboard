using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexDashboard.Styles;

/// <summary>
/// Provides CSS class styles for the MainLayout component.
/// </summary>
internal readonly record struct MainLayoutStyles
{
    private static readonly string _container = ElementClass.Empty()
        .Add("flex")
        .Add("h-screen")
        .Add("overflow-hidden")
        .ToString();

    private static readonly string _contentArea = ElementClass.Empty()
        .Add("flex-1")
        .Add("flex")
        .Add("flex-col")
        .Add("overflow-hidden")
        .ToString();

    private static readonly string _main = ElementClass.Empty()
        .Add("main-content")          // Uses --content-padding CSS variables
        .Add("flex-1")
        .Add("overflow-y-auto")
        .Add("bg-default-100")
        .ToString();

    public static string GetContainerStyles(string? additionalClass = null)
    {
        return ElementClass.Empty()
            .Add(_container)
            .Add(additionalClass)
            .ToString();
    }

    public static string GetContentAreaStyles() => _contentArea;

    public static string GetMainStyles() => _main;
}
