using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskManagementUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Set HttpClient to comunication with backend
builder.Services.AddScoped(sp =>
    //new HttpClient { BaseAddress = new Uri("https://localhost:7072/") }); // Sets the API URL
    new HttpClient { BaseAddress = new Uri("https://taskmanagementnik-brggfkgqdygcgace.brazilsouth-01.azurewebsites.net/") }); // Sets the API URL


await builder.Build().RunAsync();
