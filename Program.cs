using VisioLens_Blazor.Components;
using VisioLens_Blazor.Configs;
using VisioLens_Blazor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<VisioLens_Blazor.Configs.Conexao>();
builder.Services.AddScoped<VisioLens_Blazor.Models.ClienteDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.ColaboradorDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.AgendamentoDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.OrcamentoDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.PacoteDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.TipoDeSessaoDAO>();
builder.Services.AddScoped<VisioLens_Blazor.Models.PagamentoDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
