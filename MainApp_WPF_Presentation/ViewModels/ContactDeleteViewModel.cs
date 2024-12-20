using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactDeleteViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    [ObservableProperty]
    private string _headline = "Are you sure you wish to delete all?";


    [RelayCommand]
    private void Delete()
    {
        _contactService.RemoveAll();
    }

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }
    public ContactDeleteViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }
}
