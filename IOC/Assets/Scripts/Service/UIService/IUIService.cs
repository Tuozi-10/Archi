using UnityEngine;

namespace Service.UIService
{
    public interface IUIService : IService, ISwitchableService
    {
        void SetInGameCanvas(GameObject g);
    }
}
