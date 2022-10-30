using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VkClientAvalonia.GUI.Views; 

public partial class TableUserControl : UserControl {
    public TableUserControl() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}