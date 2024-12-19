using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _headline = "Create Contact";

    [RelayCommand]
    private void SwingHome()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
    }
    public ContactAddViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
