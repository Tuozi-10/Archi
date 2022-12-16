using Service;

public interface ISwitchableService : IService
{
    public void Toggle();
    
    public void Enable();

    public void Disable();

    
}
