using CommunityToolkit.Mvvm.ComponentModel;

namespace MainApp_WPF_Presentation.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;
}
