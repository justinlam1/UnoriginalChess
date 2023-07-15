using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UnoriginalChess.Application;
using UnoriginalChess.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped<IGameOutputPort<List<DropItem>>, BlazorGamePresenter>();
builder.Services.AddScoped<StartGameUseCase<List<DropItem>>>();
builder.Services.AddScoped<MakeMoveUseCase<List<DropItem>>>();
builder.Services.AddScoped<EndGameUseCase<List<DropItem>>>();

await builder.Build().RunAsync();