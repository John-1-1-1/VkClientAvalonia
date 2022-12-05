using VkClientAvalonia.Utils.Vk.SubClass;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkClientAvalonia.Utils.Vk; 

public class VkClient: IVkClient {
    private VkApi api { get; set; }

    public int Authorize(string login, string password, ulong appId ) {
        api = new VkApi();
        try {
            api.Authorize(new ApiAuthParams() {
                Login = login,
                Password = password,
                ApplicationId = appId,
                Settings = Settings.All
            });

            return 0;
        }
        catch {
            return 1;
        }
    }

    public GetConversationsResult GetMesssages(ulong offset, uint count) { 
        return api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams()
        {
            Offset = offset,
            Count = count
        });
        
    }

    public string GetUserName() {
        var userProfileInfo = api.Account.GetProfileInfo();
        return userProfileInfo.FirstName + " " + userProfileInfo.LastName;
    }


    public List<Dialog>? GetUserDialogs() {
        
        long id_line = 2000000000;
        var dialogs = api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams() {
            Count = 50
        });
        int index;
        var chats = dialogs.Items; 
        List<Dialog> listDialogs = new List<Dialog>();

        List<long> listUsersId = new List<long>();


        for (index = 0; index < chats.Count; index++) {
            if (chats[index].Conversation.Peer.Type.ToString() == "chat") {
                listDialogs.Add(new Dialog(chats[index].Conversation.Peer.Id,
                    chats[index].LastMessage.Date.Value.ToString(),
                    chats[index].LastMessage.Text,
                    chats[index].Conversation.ChatSettings.Title,
                    chats[index].Conversation.UnreadCount == null? 0: 
                        chats[index].Conversation.UnreadCount.Value));
            }
            if (chats[index].Conversation.Peer.Type.ToString() == "user") {
                listDialogs.Add(new Dialog(chats[index].Conversation.Peer.Id,
                    chats[index].LastMessage.Date.Value.ToString(),
                    chats[index].LastMessage.Text,
                    chats[index].Conversation.UnreadCount == null? 0: 
                        chats[index].Conversation.UnreadCount.Value));
                listUsersId.Add(chats[index].Conversation.Peer.Id);
            }
        }

        foreach (var user in api.Users.Get(listUsersId)) {
            if (user == null) {
                continue;
            }
            for (index = 0; index < listDialogs.Count; index++) {
                if (listDialogs[index].id == user.Id) {
                    listDialogs[index].Name = user.FirstName + " " + user.LastName;
                }
            }
        }
        return listDialogs;
    }
    
    
    public void sendMessage(Dialog dialog) {
        Random rnd = new Random();
        api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
        {
            RandomId = rnd.Next(0, 2147483647),
            UserId = dialog.id,
            Message = dialog.Message
        });

    }
}