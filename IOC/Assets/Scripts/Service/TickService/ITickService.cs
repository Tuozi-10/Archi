using System;

namespace Service.TickService
{
    public interface ITickService : ISwitchableService
    {
        void Update();
        public event Action OnUpdate;
        
    }
}