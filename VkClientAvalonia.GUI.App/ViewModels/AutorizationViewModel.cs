using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App.ViewModels; 

public class AutorizationViewModel: ViewModelBase {
    public string Login { get; set; } 
    public string Password { get; set; }
    public ulong AppId { get; set; }

    private bool _ErrorTextDtateControl;

    public bool ErrorTextDtateControl {
        get => _ErrorTextDtateControl;
        set => this.RaiseAndSetIfChanged(ref _ErrorTextDtateControl, value);
    }
    public ReactiveCommand<Unit, Unit> LoginButton { get; init; }


    public AutorizationViewModel( ) {
        LoginButton = ReactiveCommand.Create(LoginButton_Click);
        ErrorTextDtateControl = false;
    }

    void LoginButton_Click() {
        
        var vkClient = SingletonContainer.GetInstance().GetContainer().GetObject<IVkClient>();
        var value = vkClient.Authorize(Login, Password, AppId);
        if (value == 0) {
            SingletonContainer.GetInstance().GetContainer().GetObject<IMainControls>().ShowDialogsControl();
        }
        else {
            ErrorTextDtateControl = true;
        }
    }
}