using Autofac;
using Autofac.Extensions.DependencyInjection;
using ConnectFour;
using iPlug;
using iPlug.Components;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//var containerBuilder = new ContainerBuilder();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<GameState>();


//autofac

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(cb =>
{
    foreach (var file in Directory.GetFiles(
        AppDomain.CurrentDomain.BaseDirectory,
        "*plugin*.dll",
        SearchOption.TopDirectoryOnly))
    {
        var assembly = Assembly.LoadFrom(file);
        cb.RegisterAssemblyModules(assembly);
    }
})).ConfigureServices(services => services.AddAutofac());


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModule());
    // ... any other Autofac registrations ...
});

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