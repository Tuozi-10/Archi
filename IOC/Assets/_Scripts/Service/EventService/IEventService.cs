namespace Service
{
    public interface IEventService : IService
    {
        void Initialize();
        void AddListener<T>(EventService.EventCallback<T> callback);
        void Trigger<T>(T triggeredKey);
        void RemoveListener<T>(EventService.EventCallback<T> callback);
        void RemoveListeners<T>(EventService.EventCallback<T> callback);
    }
}