public class SwitchableService
{
    private bool enable;
    protected bool isEnabled => enable;

    public virtual void Enable()
    {
        enable = true;
    }

    public virtual void Disable()
    {
        enable = false;
    }
    
}
