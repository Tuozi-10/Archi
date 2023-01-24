using UnityEngine;

namespace Service.UIService
{
    public interface IUIService : IService, ISwitchableService
    {
        public void AddPopUpToQueue(PopUp popUp);
        public void DisplayNextPopUp();
    }
}