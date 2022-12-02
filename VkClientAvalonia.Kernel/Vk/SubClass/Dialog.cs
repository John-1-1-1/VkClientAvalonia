namespace VkClientAvalonia.Utils.Vk.SubClass; 

public class Dialog {
    
    public string Message { get; set; }
    public long id { get; set; }
    public string? Name { get; set; }
    public string last_message_date { get; set; }
    
    public Dialog(long id,string last_message_date, string message, string name) {
        this.id = id;
        this.Name = null;
        this.Message = message;
        this.Name = name;
        if (message == "") {
            this.Message = "Файл";
        }
        this.last_message_date = last_message_date;
    }
    
    public Dialog(long id,string last_message_date, string message) {
        this.id = id;
        this.Name = null;
        this.Message = message;
        if (message == "") {
            this.Message = "Файл";
        }
        this.last_message_date = last_message_date;
    }
}