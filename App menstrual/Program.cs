using App_menstrual.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregamos AddInteractiveServerComponents() aquí
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<App_menstrual.Models.AppService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

// 2. Agregamos AddInteractiveServerRenderMode() aquí
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();