#nullable enable
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VkClientAvalonia.Utils.Data;

namespace VkClientAvalonia.Utils.UtilsToFiles;

public class GetterJson {

    public async Task SaveDataAsync(UserData data) {
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<UserData>(fs, data);
        }
    }

    public async Task<UserData?> GetDataAsync(string path) {
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            UserData? person = await JsonSerializer.DeserializeAsync<UserData>(fs);
            return person;
        }
    }
}