using System.IO;
using System.Threading.Tasks;
using VkClientAvalonia.Utils.Data;
using VkClientAvalonia.Utils.UtilsToFiles;
using Xunit;

namespace VkClientAvalonia.Tests;

public class Tests
{
    
    [Fact]
    public void TestSetDataInJson_isExist()
    {
        var user = new UserData("1", "2");
        GetterJson.SaveData(user, "test_settings.json");

        var IsExist = File.Exists("test_settings.json");
        Assert.True(IsExist);
    }
    
    [Fact]
    public void TestGetDataInJson_notNull()
    {
        var data = GetterJson.GetData("test_settings.json");
        Assert.NotNull(data);
    }
    
}