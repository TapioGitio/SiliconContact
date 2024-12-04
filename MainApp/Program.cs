using Business.Services;
using MainApp.Interfaces;
using MainApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<ContactService>();
        services.AddSingleton<StorageService>();
        services.AddSingleton<IMenuService, MenuService>();
    })
    .Build();

var run = host.Services.GetRequiredService<IMenuService>();
run.StartMenu();

