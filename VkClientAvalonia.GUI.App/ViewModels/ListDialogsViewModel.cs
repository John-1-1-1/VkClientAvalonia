using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;
using VkClientAvalonia.Utils.Vk.SubClass;

namespace VkClientAvalonia.GUI.App.ViewModels;


public class ListDialogsViewModel: ReactiveObject, IListDialogsViewModel {

    public List<Dialog> _users;
    public String _userName = "None";

    
    public String UserName {
        get => _userName;
        set => this.RaiseAndSetIfChanged(ref _userName, value);
    }

    public List<Dialog> Users {
        get => _users;
        set => this.RaiseAndSetIfChanged(ref _users, value);
    }
    
    
    public ListDialogsViewModel() {
        Users = new List<Dialog>();
        SingletonContainer.GetInstance().GetContainer().AddObject<IListDialogsViewModel>(this);
    }

    public void ShowData() {

        var vkClient = SingletonContainer.GetInstance().GetContainer().GetObject<IVkClient>();

        UserName = vkClient.GetUserName();
        
        Users = vkClient.GetUserDialogs();
    }
    
    
}