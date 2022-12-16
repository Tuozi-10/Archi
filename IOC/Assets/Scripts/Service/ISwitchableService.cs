using System.Collections.Generic;

namespace Service
{
    public interface ISwitchableService : IService
    {
        public void SwitchServiceState(bool state);
    }
}