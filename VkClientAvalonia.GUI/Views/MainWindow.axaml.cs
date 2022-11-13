using Avalonia.Controls;
using VkClientAvalonia.GUI.ViewModels;

namespace VkClientAvalonia.GUI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}