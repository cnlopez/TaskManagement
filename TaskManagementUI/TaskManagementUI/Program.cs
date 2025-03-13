using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;
using TaskManagementUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
Console.WriteLine($"API Base URL: {apiBaseUrl}");  // Debug

//var settings = await httpClient.GetFromJsonAsync<Dictionary<string, string>>("appsettings.json");
//var apiBaseUrl = settings?["ApiBaseUrl"] ?? "https://localhost:7072/";


// Set HttpClient to comunication with backend
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(apiBaseUrl) }); // Sets the API URL

await builder.Build().RunAsync();
