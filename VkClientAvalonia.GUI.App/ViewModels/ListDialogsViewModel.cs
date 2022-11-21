using System.Collections.ObjectModel;

namespace VkClientAvalonia.GUI.App.ViewModels;

public class TestUser {
    public string Name { get; set; }

    public TestUser(string Name) {
        this.Name = Name;
    }
}

public class ListDialogsViewModel {

    public ObservableCollection<TestUser> Users { get; set; }


    public ListDialogsViewModel() {
        Users = new ObservableCollection<TestUser>();
        Users.Add(new TestUser("Cat"));
        Users.Add(new TestUser("Dog"));
        Users.Add(new TestUser("Fuck"));
        Users.Add(new TestUser("You"));
        Users.Add(new TestUser("Cat"));
        Users.Add(new TestUser("Dog"));
        Users.Add(new TestUser("Fuck"));
        Users.Add(new TestUser("You"));
        Users.Add(new TestUser("Cat"));
        Users.Add(new TestUser("Dog"));
        Users.Add(new TestUser("Fuck"));
        Users.Add(new TestUser("You"));
        Users.Add(new TestUser("Cat"));
        Users.Add(new TestUser("Dog"));
        Users.Add(new TestUser("Fuck"));
        Users.Add(new TestUser("You"));
        Users.Add(new TestUser("Cat"));
        Users.Add(new TestUser("Dog"));
        Users.Add(new TestUser("Fuck"));
        Users.Add(new TestUser("You"));
    }


}