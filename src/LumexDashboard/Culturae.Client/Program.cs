using Blazor.Sonner.Extensions;
using Culturae.Client;
using Culturae.Client.Services;
using LumexUI.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5256") });

// Add LumexUI services
builder.Services.AddLumexServices();

// Add Blazor Sonner toast service
builder.Services.AddSonner();

// Add app state service
builder.Services.AddScoped<AppStateService>();

// Add project service
builder.Services.AddScoped<ProjectService>();

await builder.Build().RunAsync();
