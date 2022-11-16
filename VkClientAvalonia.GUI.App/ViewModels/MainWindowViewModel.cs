using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainControls {

    private bool _u1V;

    public AutorizationViewModel Autorization { get; set; }

    public bool u1V {
        get => _u1V;
        set => this.RaiseAndSetIfChanged(ref _u1V, value);
    }

    private bool _u2V;

    public bool u2V {
        get => _u2V;
        set => this.RaiseAndSetIfChanged(ref _u2V, value);
    }
    
    public ReactiveCommand<Unit, Unit> But { get; init; }
    
    public MainWindowViewModel() {
        Autorization = new AutorizationViewModel();
        u1V = false;
        u2V = true;
        
        But = ReactiveCommand.Create(() => {
            u1V = !u1V;
            u2V = !u2V;
        });
        
        var singleton = SingletonContainer.GetInstance();
        singleton.GetContainer().AddObject<IMainControls>(this);
    }

    
    public void ShowAutorizationControl() {
        throw new System.NotImplementedException();
    }

    public void ShowDialogsControl() {
        u1V = !u1V;
        u2V = !u2V;
    }
}

public interface IMainControls {
    public void ShowAutorizationControl();

    public void ShowDialogsControl();
}

