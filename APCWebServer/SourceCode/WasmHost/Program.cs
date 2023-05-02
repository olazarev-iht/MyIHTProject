using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WasmHost;
using MudBlazor.Services;
using SharedComponents.Services;
using WasmHost.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ICuttingParametersService, HttpCuttingParametersService>();

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("https://localhost:7182/api/v1/"), });

builder.Services.AddMudServices();

await builder.Build().RunAsync();
