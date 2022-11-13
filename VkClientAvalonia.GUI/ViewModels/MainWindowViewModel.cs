using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.GUI.Views;
using VkClientAvalonia.GUI.Views.UserControls;
using VkClientAvalonia.Utils.Containers;

namespace VkClientAvalonia.GUI.ViewModels;

public class MainWindowViewModel : ViewModelBase {

    private bool _isVisibleAutorizationControl = true;

    public bool h {
        get => _isVisibleAutorizationControl;
        set => this.RaiseAndSetIfChanged(ref _isVisibleAutorizationControl, value);
    }
    private bool _u1V;

    public bool u1V
    {
        get => _u1V;
        set => this.RaiseAndSetIfChanged(ref _u1V, value);
    }
    public ReactiveCommand<Unit, Unit> But { get; init; }
        
    public MainWindowViewModel() {
        h = false;

        But = ReactiveCommand.Create(() => {
            u1V = !u1V;
        });
    }
}

