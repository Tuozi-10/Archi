namespace Service
{
    public class SwitchableService : ISwitchableService
    {
        public void Toggle(bool active)
        {
            if (active)
            {
                Enable();
                return;
            }

            Disable();
        }

        public virtual void Enable()
        {
            isActive = true;
        }

        public virtual void Disable()
        {
            isActive = false;
        }

        public bool isActive { get; set; }
    }
}