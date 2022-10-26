namespace VkClientAvalonia.Utils.Containers; 

public class ContextContainer {
    public HashSet<Type> KeyItems { get; set; }
    
    private  Dictionary<Type, object> Context { get; set; }

    public ContextContainer() {
        KeyItems = new HashSet<Type>();
        Context = new Dictionary<Type, object>();
    }
    
    public void AddObject<ITypeObj>(ITypeObj obj) {
        
        var key = typeof(ITypeObj);
        
        var haskey = KeyItems.Add(key);
        
        if (!haskey) {
            throw new ArgumentNullException("The container has this key already");
        }
        if (obj == null) {
            throw new ArgumentNullException(nameof(obj));
        }

        Context.Add(key, obj);
    }

    public TypeObj GetObject<TypeObj>() {

        Type? key = null;

        foreach (var keyContainerItem in KeyItems) {
            if (keyContainerItem == typeof(TypeObj)) {
                key = keyContainerItem;
                break;
            }
        }

        if (key == null) {
            throw new ArgumentNullException($"{nameof(key)}");
        }

        object? obj = null;

        Context.TryGetValue(key, out obj);

        if (obj == null) {
            throw new ArgumentNullException($"{nameof(obj)}");
        }

        return (TypeObj)obj;
    }
}