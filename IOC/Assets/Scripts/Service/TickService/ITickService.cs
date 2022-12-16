using System;
using UnityEngine.PlayerLoop;

namespace Service.TickService
{
    public interface ITickService : ISwitchableService
    {
        void Update();
        public event Action OnUpdate;
    }
}