using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkClientAvalonia.GUI.App.ViewModels;

namespace VkClientAvalonia.GUI.App.Views.Controls; 

public partial class AutorizationControl : UserControl {
    public AutorizationControl() {

        DataContext = new AutorizationViewModel();
        
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}