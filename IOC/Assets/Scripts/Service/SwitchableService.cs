public class SwitchableService : ISwitchableService
{
    public bool enable { get; private set; }

    public virtual void Toggle()
    {
        enable = !enable;
    }

    public virtual void Enable()
    {
        enable = true;
    }

    public virtual void Disable()
    {
        enable = false;
    }
    
}
