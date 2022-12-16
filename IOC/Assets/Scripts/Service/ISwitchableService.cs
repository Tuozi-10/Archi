using Service;

public interface ISwitchableService : IService
{
    public void Enable();

    public void Disable();
}
