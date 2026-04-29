using LumexDashboard.Client.Services;
using LumexUI.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add LumexUI services
builder.Services.AddLumexServices();

// Add app state service
builder.Services.AddScoped<AppStateService>();

await builder.Build().RunAsync();
