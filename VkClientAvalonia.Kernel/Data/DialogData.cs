namespace VkClientAvalonia.Utils.Data; 

public class DialogData {
    public string NameFriend { get; set; }
    public string TextMessage { get; set; }

    public DialogData(string nameFriend, string textMessage) {
        NameFriend = nameFriend;
        TextMessage = textMessage;
    }
}