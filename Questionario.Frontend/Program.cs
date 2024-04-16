using Questionario.Frontend.Components;
using Questionario.Frontend.Models;
using Questionario.Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IQuestionario<Convenio>, ConvenioService>();
builder.Services.AddScoped<IQuestionario<FaixaIdade>, FaixaIdadeService>();
builder.Services.AddScoped<IQuestionario<FaixaSalarial>, FaixaSalarialService>();
builder.Services.AddScoped<IQuestionario<MotivoEmprestimo>, MotivoEmprestimoService>();
builder.Services.AddScoped<IResposta, RespostaService>();

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
