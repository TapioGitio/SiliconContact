using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MainApp_WPF_Presentation
{

    public partial class App : Application
    {
        IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IStorageService, StorageService>();
    })
    .Build();

    }

}
