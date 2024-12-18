using MainApp_WPF_Presentation.ViewModels;
using System.Windows;

namespace MainApp_WPF_Presentation;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}