using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App.ViewModels; 

public class AutorizationViewModel: ViewModelBase {
    public string Login { get; set; }
    public ulong AppId { get; set; }
    
    private string _password;

    public string Password {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }


    private bool _ErrorTextDtateControl;

    public bool ErrorTextDtateControl {
        get => _ErrorTextDtateControl;
        set => this.RaiseAndSetIfChanged(ref _ErrorTextDtateControl, value);
    }
    
    public ReactiveCommand<Unit, Unit> LoginButton { get; init; }

    public AutorizationViewModel( ) {
        LoginButton = ReactiveCommand.Create(LoginButton_Click);
        ErrorTextDtateControl = false;
        AppId = 6121396;
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