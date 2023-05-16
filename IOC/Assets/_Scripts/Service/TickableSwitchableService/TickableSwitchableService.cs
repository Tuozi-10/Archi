namespace Service
{
    public class TickableSwitchableService : TickableService, ITickableSwitchableService
    {
        public override void OnUpdate()
        {
            base.OnUpdate();
        }

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
}
