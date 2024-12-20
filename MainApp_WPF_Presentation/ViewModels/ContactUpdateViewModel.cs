using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    [ObservableProperty]
    private string _headline = "Change Email";

    [ObservableProperty]
    private string _nameInput;

    [ObservableProperty]
    private string _newEmail;

    [ObservableProperty]
    private bool _doTheyExist;


    partial void OnNameInputChanged(string value)
    {
        
        if(_contactService.ContactExists(value))
        {
            DoTheyExist = true;
        }
        else
        {
            DoTheyExist = false;
        }
    }

    [RelayCommand]
    private void ChangeEmail()
    {
        if (DoTheyExist)
        {
            _contactService.Update(NameInput, NewEmail);
        }
        else
        {
            return;
        }
    }

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }
    public ContactUpdateViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }
}
