using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VkClientAvalonia.GUI.App.Views.Controls; 

public partial class Dialogs : UserControl {
    public Dialogs() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}