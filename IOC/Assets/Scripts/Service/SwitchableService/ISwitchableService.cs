using Service;

public interface ISwitchableService : IService
{
    void Switch();
    void Enable();
    void Disable();
}
