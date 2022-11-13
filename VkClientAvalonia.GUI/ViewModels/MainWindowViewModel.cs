using VkClientAvalonia.GUI.Views;
using VkClientAvalonia.GUI.Views.UserControls;
using VkClientAvalonia.Utils.Containers;

namespace VkClientAvalonia.GUI.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel {

    public ContentWindow ContentWindow { get; set; }

    public MainWindowViewModel() {
        ContentWindow = new ContentWindow();
    }

    public void OpenNewContentWindow(object new_content) {
        ContentWindow = new ContentWindow();
        ContentWindow.Content = new_content;
    }
    
}

public interface IMainWindowViewModel {
    public void OpenNewContentWindow(object new_content);
}

public interface IContentWindow {

    public object? Content { get; set; }
}

public class ContentWindow : IContentWindow {

    public object? Content { get; set; }

    public ContentWindow() {
        Content = null;
    }
}
