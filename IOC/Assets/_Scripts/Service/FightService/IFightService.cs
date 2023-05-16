using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public interface IFightService : ISwitchableService
    {
        void InitializeGame();
    }
}
