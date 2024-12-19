using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;

    [ObservableProperty]
    private string _headline = "Main Menu";



[RelayCommand]
    private void SwingToAddPage()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();
    }
    [RelayCommand]
    private void SwingToUpdatePage()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactUpdateViewModel>();
    }
    [RelayCommand]
    private void SwingToShowPage()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactDisplayViewModel>();
    }
    [RelayCommand]
    private void SwingToDeletePage()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactDeleteViewModel>();
    }
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }
}
