using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VkClientAvalonia.Utils.Data;

namespace VkClientAvalonia.Utils.UtilsToFiles;

public static class GetterJson {

    public static void SaveData<TInp>(TInp data, string path)
    {
        string jsonData = JsonSerializer.Serialize<TInp>( data);
        File.WriteAllText(path, jsonData);   
    }

    public static TInp? GetData<TInp>(string path) {
        string text = File.ReadAllText(path);
        return JsonSerializer.Deserialize<TInp>(text);
    }
}