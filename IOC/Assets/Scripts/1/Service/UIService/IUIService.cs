using UnityEngine;

namespace Service.UIService
{
    public interface IUIService : IService
    {
        void DisplayMainMenu();
        void DisplayPopUp();
    }
}
