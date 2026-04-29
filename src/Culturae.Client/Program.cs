using System.Globalization;
using Blazor.Sonner.Extensions;
using Culturae.Client;
using Culturae.Client.Services;
using LumexUI.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5256") });

// Add LumexUI services
builder.Services.AddLumexServices();

// Add Blazor Sonner toast service
builder.Services.AddSonner();

// Add localization services
builder.Services.AddLocalization();

// Add app state service
builder.Services.AddScoped<AppStateService>();

// Add project service
builder.Services.AddScoped<ProjectService>();

var host = builder.Build();

// Restore saved language preference from localStorage
var jsInProcess = host.Services.GetRequiredService<IJSRuntime>() as IJSInProcessRuntime;
var savedCulture = jsInProcess?.Invoke<string?>("localStorage.getItem", "culture");
if (!string.IsNullOrEmpty(savedCulture))
{
    var culture = new CultureInfo(savedCulture);
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}

await host.RunAsync();
