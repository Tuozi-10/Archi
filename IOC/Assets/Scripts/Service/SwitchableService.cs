public class SwitchableService : ISwitchableService
{
    private bool enable;
    protected bool isEnabled => enable;

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
