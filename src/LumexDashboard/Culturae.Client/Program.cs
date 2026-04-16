using Blazor.Sonner.Extensions;
using Culturae.Client;
using Culturae.Client.Services;
using LumexUI.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add LumexUI services
builder.Services.AddLumexServices();

// Add Blazor Sonner toast service
builder.Services.AddSonner();

// Add app state service
builder.Services.AddScoped<AppStateService>();

await builder.Build().RunAsync();
