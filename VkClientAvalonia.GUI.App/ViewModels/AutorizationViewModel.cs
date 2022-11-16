using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.App.ViewModels; 

public class AutorizationViewModel {
    public string Login { get; set; } 
    public string Password { get; set; }
    
    public ulong AppId { get; set; }

    public ReactiveCommand<Unit, Unit> LoginButton { get; init; }


    public AutorizationViewModel( ) {
        LoginButton = ReactiveCommand.Create(LoginButton_Click);

    }

    void LoginButton_Click() {
        
        var vkClient = SingletonContainer.GetInstance().GetContainer().GetObject<IVkClient>();
        var value = vkClient.Authorize(Login, Password, AppId);
        SingletonContainer.GetInstance().GetContainer().GetObject<IMainControls>().ShowDialogsControl();
        if (value == 0) {
            
        }
        else {
            
        }
    }
}