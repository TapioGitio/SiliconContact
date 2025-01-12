using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;
    public ContactAddViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _contacts = new ObservableCollection<ContactEntity>();
    }

    [ObservableProperty]
    private string _headline = "Create Contact";

    [ObservableProperty]
    private string _successMessage = null!;

    [ObservableProperty]
    private string _errorMessage = null!;

    [ObservableProperty]
    private ContactRegistrationForm _regForm = new();

    [ObservableProperty]
    private ObservableCollection<ContactEntity> _contacts = new ObservableCollection<ContactEntity>();

    [RelayCommand]
    private void Save()
    {
        RegForm.Validate();

        if (_contactService.ContactExists(RegForm.FirstName))
        {
            ErrorMessage = "Contact already exists.";
            SuccessMessage = null!;
            return;
        }
        else if (RegForm.HasErrors)
        {
            ErrorMessage = "Encountered an error, please check your spelling.";
            
        }
        else
        {
        _contactService.AddContact(RegForm);
        ErrorMessage = null!;
        SuccessMessage = "Contact was created.";
        }
    }

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }

}
