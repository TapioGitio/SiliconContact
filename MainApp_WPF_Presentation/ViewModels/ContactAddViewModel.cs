using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;
    public ContactAddViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }

    [ObservableProperty]
    private string _headline = "Create Contact";

    [ObservableProperty]
    private ContactRegistrationForm _regForm = new();


    [RelayCommand]
    private void Save()
    {
        _contactService.AddContact(RegForm);
    }

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }
}
