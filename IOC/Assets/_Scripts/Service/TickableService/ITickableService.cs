using Service;

public interface ITickableService : IService
{
    double tickRate { get; }
    void OnUpdate();
}
