using VkClientAvalonia.GUI.Views;

namespace VkClientAvalonia.GUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {

    public ContentWindow ContentWindow { get; set; }

    public MainWindowViewModel() {
        ContentWindow = new ContentWindow();
        ContentWindow.Content = new TableUserControl();
    }
    
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
