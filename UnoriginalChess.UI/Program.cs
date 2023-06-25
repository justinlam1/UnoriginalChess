using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using UnoriginalChess.Application;
using UnoriginalChess.UI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddScoped<IGameOutputPort<List<DropItem>>, BlazorGamePresenter>();
builder.Services.AddScoped<StartGameUseCase<List<DropItem>>>();
builder.Services.AddScoped<MakeMoveUseCase<List<DropItem>>>();
builder.Services.AddScoped<EndGameUseCase<List<DropItem>>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();