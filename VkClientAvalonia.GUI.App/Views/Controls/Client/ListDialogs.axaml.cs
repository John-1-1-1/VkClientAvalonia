using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VkClientAvalonia.GUI.App.ViewModels;

namespace VkClientAvalonia.GUI.App.Views.Controls.Client; 

public partial class ListDialogs : UserControl {
    public ListDialogs() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);

        DataContext = new ListDialogsViewModel();
    }
}