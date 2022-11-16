using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VkClientAvalonia.GUI.App.Views.Controls.Autorization; 

public partial class AutorizationMediator : UserControl {
    public AutorizationMediator() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}