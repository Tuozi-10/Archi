namespace Service
{
    public interface ISwitchableService : IService
    {
        bool isActive{ get; set; }
        
        void Toggle();

        void Enable();

        void Disable();
    }
}
