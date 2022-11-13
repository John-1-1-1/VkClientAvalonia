using System;
using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.GUI.Views;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;

namespace VkClientAvalonia.GUI.ViewModels; 

public class AutorizationWindowViewModel: ViewModelBase {

    public string Login { get; set; } 
    public string Password { get; set; }
    
    public ulong AppId { get; set; }

    public ReactiveCommand<Unit, Unit> LoginButton { get; init; }


    public AutorizationWindowViewModel( ) {
        LoginButton = ReactiveCommand.Create(LoginButton_Click);

    }

    private MainWindowViewModel mainWindowViewModel;
    public AutorizationWindowViewModel(MainWindowViewModel mainWindowViewModel) {
        LoginButton = ReactiveCommand.Create(LoginButton_Click);
    }

    void LoginButton_Click() {
        
        var vkClient = SingletonContainer.GetInstance().GetContainer().GetObject<IVkClient>();
        var value = vkClient.Authorize(Login, Password, AppId);

        if (value == 0) {
            
        }
        else {
            
        }
    }
}