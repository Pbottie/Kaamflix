using Kaamiflix.Common.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<MembershipHttpClient>(client => client.BaseAddress = new Uri("https://localhost:7001/api/"));
builder.Services.AddScoped<IMembershipService,MembershipService>();


await builder.Build().RunAsync();
