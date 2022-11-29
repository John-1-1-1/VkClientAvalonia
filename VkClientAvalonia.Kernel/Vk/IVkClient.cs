using VkClientAvalonia.Utils.Vk.SubClass;
using VkNet.Model;

namespace VkClientAvalonia.Utils.Vk; 

public interface IVkClient {

    public int Authorize(string login, string password, ulong appId);

    public GetConversationsResult GetMesssages(ulong offset, uint count);

    public List<Dialog>? GetUserDialogs();
    
    public string GetUserName();
}