using System.Text.Json;

namespace VkClientAvalonia.Utils.GetterFiles;

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