using DesignPatterns;
using Service;

public interface IEventManagerService : IService
{
    public void AddListener<T>(EventManagerService.EventCallback<T> callback);
    public void AddListeners<T>(params EventManagerService.EventCallback<T>[] callbacks);
    public void RemoveListeners<T>();

    public void RemoveListener<T>(EventManagerService.EventCallback<T> callback);
    public void Trigger<T>(T triggeredKey);

}
