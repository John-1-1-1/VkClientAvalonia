namespace VkClientAvalonia.Utils.Vk; 

public interface IVkClient {

    public int Authorize(string login, string password, ulong appId);
    
}