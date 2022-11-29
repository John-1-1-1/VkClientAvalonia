using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VkClientAvalonia.GUI.App.Views.Controls.Client.Messenger; 

public partial class MessengerMediator : UserControl {
    public MessengerMediator() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}