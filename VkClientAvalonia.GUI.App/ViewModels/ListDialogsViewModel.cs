using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls.Selection;
using ReactiveUI;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Vk;
using VkClientAvalonia.Utils.Vk.SubClass;

namespace VkClientAvalonia.GUI.App.ViewModels;


public class ListDialogsViewModel: ReactiveObject, IListDialogsViewModel {

    public List<Dialog> _users;
    public String _userName = "None";
    public SelectionModel<Dialog> Selection { get; set; }

    public MessengerViewModel MessengerViewModel { get; set; } = new MessengerViewModel();
    
    private bool _isMessengerShow;
    public bool IsMessengerShow 
    {
        get => _isMessengerShow;
        set => this.RaiseAndSetIfChanged(ref _isMessengerShow, value);
    }
    
    private bool _isListDialogShow;
    public bool IsListDialogShow
    {
        get => _isListDialogShow;
        set => this.RaiseAndSetIfChanged(ref _isListDialogShow, value);
    }

    public void ShowListDialog() {
        IsMessengerShow = false;
        IsListDialogShow = true;
    }

    public void ShowMessenger() {
        IsMessengerShow = true;
        IsListDialogShow = false;
    }
    
    public ReactiveCommand<Unit, Unit> Exit { get; set; }

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
        ShowListDialog();
        Selection = new SelectionModel<Dialog>();

        Selection.SelectionChanged += SelectedChanged;
        
        SingletonContainer.GetInstance().GetContainer().AddObject<IListDialogsViewModel>(this);
        Exit = ReactiveCommand.Create( () => 
            SingletonContainer.GetInstance().GetContainer().
                GetObject<IMainControls>().ShowAutorizationControl());
    }
    
    private void SelectedChanged(object? sender, SelectionModelSelectionChangedEventArgs<Dialog> e) {
        var item = ((SelectionModel<Dialog>)sender).SelectedItem;
        if (item == null) {
            throw new ArgumentNullException();
        }
        SingletonContainer.GetInstance().GetContainer().GetObject<IMessengerViewModel>().ChangeDialog(item);
        ShowMessenger();
    }
    
    public void ShowData() {

        var vkClient = SingletonContainer.GetInstance().GetContainer().GetObject<IVkClient>();

        UserName = vkClient.GetUserName();
        
        Users = vkClient.GetUserDialogs();
    }
}

public interface IListDialogsViewModel {
    public void ShowData();

    public void ShowListDialog();

    public void ShowMessenger();
}