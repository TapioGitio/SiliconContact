using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactDisplayViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;
    public ContactDisplayViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _contacts = new ObservableCollection<Contact>(_contactService.Display());
    }

    [ObservableProperty]
    private string _headline = "Contact List";

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts;


    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }


    [RelayCommand]
    private void DeleteOne(Contact contact)
    {
        //Got help from ai for the IF statement here to trigger the change
        //to appear as it should, I was at first trying to make a new instanciation
        //but that made a whole new list instead.
        if (Contacts.Contains(contact))
        {
            _contactService.RemoveOne(contact);
            Contacts.Remove(contact);
        }
    }
}
