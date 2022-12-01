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
        var dialogs = api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams());
        var chats = dialogs.Items;
        
        var ids = chats.Select(x => x.Conversation.Peer.Id).ToList();

        var listDialogs = chats
            .Select(x => new Dialog(x.Conversation.Peer.Id,
                x.LastMessage.Date.ToString(),
                x.LastMessage.Text)).ToList();
        
        var ids_user = ids.Select(x => x).Where(i => i < id_line).ToList();
        var ids_chats = ids.Where(i => i >= id_line).Select(x => x - id_line).ToList();

        var users_names = api.Users.Get(ids_user);
        var dialogs_names = api.Messages.GetChat( chatIds: ids_chats);

        for (int i = 0; i < listDialogs.Count; i++) {
            var user_name = users_names.SingleOrDefault(x => x.Id == listDialogs[i].id, null);
            var dialog_name = dialogs_names.SingleOrDefault(x => x.Id == listDialogs[i].id - id_line, null);

            if (user_name != null) {
                listDialogs[i].Name = user_name.FirstName + " " + user_name.LastName;
            }
            else if (dialog_name != null) {
                listDialogs[i].Name = dialog_name.Title;
            }
            else {
            
                listDialogs.RemoveAt(i);
            }
        }

        return listDialogs;
    }

    public void sendMessage() {
        
    }
}