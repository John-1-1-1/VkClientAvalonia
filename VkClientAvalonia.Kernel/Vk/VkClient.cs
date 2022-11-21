using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkClientAvalonia.Utils.Vk; 

public class VkClient: IVkClient {
    
    private VkApi api = new VkApi();

    public int Authorize(string login, string password, ulong appId ) {
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

    public MessagesGetObject Get20Messsages(int offset, uint count) {
        return api.Messages.GetDialogs(new VkNet.Model.RequestParams.MessagesDialogsGetParams
        {
            Offset = offset,
            Count = count
        });
    }
    
    
}