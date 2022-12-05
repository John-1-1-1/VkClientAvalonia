namespace VkClientAvalonia.Utils.Vk.SubClass; 

public class Dialog {
    
    public string Message { get; set; }
    public long id { get; set; }
    public string? Name { get; set; }
    public string last_message_date { get; set; }
    public long UnreadMessages { get; set; }

    public bool VisibleUnreadNumber => UnreadMessages != 0;
    public Dialog(long id,string last_message_date, string message, string name, long unreadMessages) {
        this.id = id;
        this.Name = null;
        this.Message = message;
        this.Name = name;
        this.UnreadMessages = unreadMessages;
        if (message == "") {
            this.Message = "Файл";
        }
        this.last_message_date = last_message_date;
    }
    
    public Dialog(long id,string last_message_date, string message, long unreadMessages) {
        this.id = id;
        this.Name = null;
        this.Message = message;
        this.UnreadMessages = unreadMessages;
        if (message == "") {
            this.Message = "Файл";
        }
        this.last_message_date = last_message_date;
    }

    public Dialog() {
        this.id = 0;
        this.last_message_date = "None";
        this.Message = "None";
        this.UnreadMessages = 1;
        this.Name = "Name";
    }
}