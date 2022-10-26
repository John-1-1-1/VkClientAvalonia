using System.IO;
using System.Threading.Tasks;
using VkClientAvalonia.Utils.Containers;
using VkClientAvalonia.Utils.Data;
using VkClientAvalonia.Utils.UtilsToFiles;
using Xunit;

namespace VkClientAvalonia.Tests;

public class Tests {
    private string FilePath { get; init; }

    public Tests() {
        FilePath = "test_settings.json";
    }

    [Fact]
    public void TestSetDataInJson_isExist() {
        File.Delete(FilePath);
        var user = new UserData("1", "2");
        GetterJson.SaveData(user, FilePath);

        var IsExist = File.Exists(FilePath);
        Assert.True(IsExist);
        File.Delete(FilePath);
    }

    [Fact]
    public void TestGetDataInJson_notNull() {
        var user = new UserData("1", "2");
        GetterJson.SaveData(user, FilePath);
        var data = GetterJson.GetData<UserData>(FilePath);
        Assert.NotNull(data);

        File.Delete(FilePath);
    }

    [Fact]
    public void SingletonContainer_is_singleton() {
        var s1 = SingletonContainer.GetInstance();
        var s2 = SingletonContainer.GetInstance();
        Assert.True(s1.GetHashCode() == s2.GetHashCode());
    }

    [Fact]
    public void SingletonContainer_addedObjects() {
        var s = SingletonContainer.GetInstance();
        var container = s.GetContainer();
        container.AddObject<IForTests, ForTests>();

        var s1 = SingletonContainer.GetInstance();
        var container1 = s1.GetContainer();

        Assert.NotNull(container1.GetObject<IForTests>());
    }
}

internal class ForTests : IForTests {
    public ForTests() {
    }
}

internal interface IForTests {
}