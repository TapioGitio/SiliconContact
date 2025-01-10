using Business.Interfaces;
using Business.Models;
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
    private string _errorMessage = null!;

    [ObservableProperty]
    private string _successMessage = null!;

    [ObservableProperty]
    private ObservableCollection<ContactEntity> _contacts;

    [RelayCommand]
    private void Delete()
    {
        if(Contacts.Any())
        {
            _contactService.RemoveAll();
            SuccessMessage = "Contacts removed succesfully.";
            ErrorMessage = null!;

        }
        else
        {
            ErrorMessage = "Storage empty, nothing to remove.";
            SuccessMessage = null!;
        }
    }

    private void LoadContacts(IStorageService storageService)
    {
        try
        {
            var loadedContacts = storageService.LoadContactsFromStorage();

            foreach (var contact in loadedContacts)
            {
                Contacts.Add(contact);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load contacts: {ex.Message}";
        }

    }

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }
    public ContactDeleteViewModel(IServiceProvider serviceProvider, IContactService contactService, IStorageService storageService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _contacts = new ObservableCollection<ContactEntity>();
        LoadContacts(storageService);

    }
}
