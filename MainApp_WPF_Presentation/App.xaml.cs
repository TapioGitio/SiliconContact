using Business.Interfaces;
using Business.Services;
using MainApp_WPF_Presentation.ViewModels;
using MainApp_WPF_Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace MainApp_WPF_Presentation;


public partial class App : Application
{
    IHost _host = Host.CreateDefaultBuilder()

        .ConfigureServices(services =>
        {
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<IStorageService, StorageService>();

            services.AddTransient<ContactDisplayViewModel>();
            services.AddTransient<ContactAddViewModel>();
            services.AddTransient<ContactUpdateViewModel>();
            services.AddTransient<ContactDeleteViewModel>();

            services.AddTransient<ContactDisplayView>();
            services.AddTransient<ContactAddView>();
            services.AddTransient<ContactUpdateView>();
            services.AddTransient<ContactDeleteView>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

        })
        .Build();

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<ContactDisplayViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
