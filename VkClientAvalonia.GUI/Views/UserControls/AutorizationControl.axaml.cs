using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkClientAvalonia.GUI.ViewModels;

namespace VkClientAvalonia.GUI.Views.UserControls; 

public partial class AutorizationControl : UserControl {
    public AutorizationControl() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
        DataContext = new AutorizationWindowViewModel();
    }
}