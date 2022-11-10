namespace VkClientAvalonia.Utils.Containers; 

public class SingletonContainer {

    private static SingletonContainer? _container { get; set; }

    private ContextContainer Context { get; set; }

    
    private static object syncRoot = new Object();
    public static SingletonContainer GetInstance() {
        if (_container == null) {
            lock (syncRoot) {
                if (_container == null) {
                    _container = new SingletonContainer();
                }
            }
        }

        return _container;
    }
    
    protected SingletonContainer() {
        Context = new ContextContainer();
    }

    public ContextContainer GetContainer() {
        return Context;
    }
}