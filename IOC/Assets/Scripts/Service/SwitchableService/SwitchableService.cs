using Service;

public class SwitchableService : ISwitchableService
{
    public bool isActive { get; set; }

    public virtual void Toggle()
    {
        isActive = !isActive;
    }

    public virtual void Enable()
    {
        isActive = true;
    }

    public virtual void Disable()
    {
        isActive = false;
    }
}
