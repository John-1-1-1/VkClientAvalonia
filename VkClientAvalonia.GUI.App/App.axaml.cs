using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using VkClientAvalonia.GUI.App.ViewModels;
using VkClientAvalonia.GUI.App.Views;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App {
    
    public partial class App : Application {

        public override void Initialize() {
            InitializeDesigner();
            AvaloniaXamlLoader.Load(this);
        }

        public static void InitializeDesigner() {
        }
        
        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new MainWindow {
                    DataContext = new MainWindowViewModel(),
                };
            }
            
            var singleton = SingletonContainer.GetInstance();
            singleton.GetContainer().AddObject<IVkClient, VkClient>();
            base.OnFrameworkInitializationCompleted();
        }
    }
}