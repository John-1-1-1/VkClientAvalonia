using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Data;
using VkClientAvalonia.Utils.Vk.SubClass;

namespace VkClientAvalonia.GUI.App.ViewModels; 

public class MessengerViewModel: ViewModelBase, IMessengerViewModel {
    
    private List<DialogData> listDialog { get; set; }

    private string _friendName;
    public string FriendName
    {
        get => _friendName;
        set => this.RaiseAndSetIfChanged(ref _friendName, value);
    }

    public ReactiveCommand<Unit, Unit> Exit { get; set; }
    
    public MessengerViewModel() {
        SingletonContainer.GetInstance().GetContainer()
            .AddObject<IMessengerViewModel>(this);
        
        Exit = ReactiveCommand.Create( () => 
            SingletonContainer.GetInstance().GetContainer().
                GetObject<IListDialogsViewModel>().ShowListDialog());
    }

    public void ChangeDialog(Dialog dialog) {

        FriendName = dialog.Name;
    }
}

interface IMessengerViewModel {
    public void ChangeDialog(Dialog dialog);
}