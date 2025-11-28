using LumexUI.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add LumexUI services
builder.Services.AddLumexServices();

await builder.Build().RunAsync();
