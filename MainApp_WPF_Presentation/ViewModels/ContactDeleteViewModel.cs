using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactDeleteViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    [ObservableProperty]
    private string _headline = "Are you sure you wish to delete all?";

    [ObservableProperty]
    private string _errorMessage = "";

    [ObservableProperty]
    private string _succesMessage = "";

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts;

    [RelayCommand]
    private void Delete()
    {
        if(Contacts.Any())
        {
            _contactService.RemoveAll();
            SuccesMessage = "Contacts removed succesfully";

        }
        else
        {
            ErrorMessage = "Storage empty, nothing to remove";
        }
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
