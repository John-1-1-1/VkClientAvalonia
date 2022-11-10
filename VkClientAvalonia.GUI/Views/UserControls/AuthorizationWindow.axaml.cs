using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkClientAvalonia.GUI.ViewModels;

namespace VkClientAvalonia.GUI.Views.UserControls; 

public partial class AuthorizationWindow : UserControl {
    
    public AuthorizationWindow() {
        InitializeComponent();
        
        DataContext = new AutorizationWindowViewModel();
    }
    
    public AuthorizationWindow(MainWindowViewModel mainWindowViewModel) {
        InitializeComponent();
        
        DataContext = new AutorizationWindowViewModel(mainWindowViewModel);
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
        
    }
}