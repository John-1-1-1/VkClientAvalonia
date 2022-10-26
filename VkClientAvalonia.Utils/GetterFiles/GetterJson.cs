using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VkClientAvalonia.Utils.Data;

namespace VkClientAvalonia.Utils.UtilsToFiles;

public static class GetterJson {

    public static void SaveData(UserData data, string path)
    {
        string jsonData = JsonSerializer.Serialize<UserData>( data);
        File.WriteAllText(path, jsonData);   
    }

    public static UserData GetData(string path) {
        string text = File.ReadAllText(path);
        return JsonSerializer.Deserialize<UserData>(text);
    }
}