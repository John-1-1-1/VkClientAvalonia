using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainControls {

    private bool _dialogControlStateShow;

    public AutorizationViewModel Autorization { get; set; }

    public bool DialogControlStateShow {
        get => _dialogControlStateShow;
        set => this.RaiseAndSetIfChanged(ref _dialogControlStateShow, value);
    }

    private bool _autorizationControlStateShow;

    public bool AutorizationControlStateShow {
        get => _autorizationControlStateShow;
        set => this.RaiseAndSetIfChanged(ref _autorizationControlStateShow, value);
    }
    
    public ReactiveCommand<Unit, Unit> But { get; init; }
    
    public MainWindowViewModel() {
        Autorization = new AutorizationViewModel();
        DialogControlStateShow = false;
        AutorizationControlStateShow = true;
        
        But = ReactiveCommand.Create(() => {
            DialogControlStateShow = !DialogControlStateShow;
            AutorizationControlStateShow = !AutorizationControlStateShow;
        });
        
        var singleton = SingletonContainer.GetInstance();
        singleton.GetContainer().AddObject<IMainControls>(this);
    }

    
    public void ShowAutorizationControl() {
        DialogControlStateShow = false;
        AutorizationControlStateShow = true;
    }

    public void ShowDialogsControl() {
        DialogControlStateShow = true;
        AutorizationControlStateShow = false;
        SingletonContainer.GetInstance().GetContainer().GetObject<IListDialogsViewModel>().ShowData();
    }
}

public interface IMainControls {
    public void ShowAutorizationControl();

    public void ShowDialogsControl();
}

