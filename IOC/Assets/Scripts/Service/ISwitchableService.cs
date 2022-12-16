using System.Collections.Generic;

namespace Service
{
    public interface ISwitchableService : IService
    {
        public void SetServiceState(bool state);
        public void SwitchServiceState();
        
    }
}