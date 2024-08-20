using IfroAlimenta.Components;
using IfroAlimenta.Controllers;
using IfroAlimenta.Contexto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<CardapioController>(); // Implementa��o
builder.Services.AddScoped<OpcaoCardapioController>(); // Implementa��o
builder.Services.AddScoped<ProdutoController>(); // Implementa��o
builder.Services.AddScoped<SugestaoController>(); // Implementa��o
builder.Services.AddScoped<NotaController>(); // Implementa��o
builder.Services.AddScoped<UsuarioController>(); // Implementa��o

//Conex�o com o banco de dados usando MySql
string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options => options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

builder.Services.AddHttpClient();

app.MapRazorPages();
app.MapFallbackToPage("/_Host");
