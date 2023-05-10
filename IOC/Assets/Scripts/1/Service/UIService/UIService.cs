using System.Linq.Expressions;
using Addressables;
using Attributes;
using UnityEngine;

namespace Service.UIService
{
    public class UIService : IUIService
    {
        private GameObject mainMenu;
        private bool isLoading;
        private GameObject PopUp;
        private bool isLoading2;
        public void DisplayMainMenu()
        {
            if (isLoading) return;
            if (mainMenu != null) mainMenu.SetActive(true);
            else AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("MainMenu", AssignMainMenu);
        }

        private void AssignMainMenu(GameObject gameObject)
        {
            isLoading = false;
            mainMenu = GameObject.Instantiate(gameObject);
        }
        
        public void DisplayPopUp()
        {
            if (isLoading2) return;
            if (PopUp != null) PopUp.SetActive(true);
            else AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("CanvasPopUp", AssignPopUp);
        }

        private void AssignPopUp(GameObject gameObject)
        {
            isLoading2 = false;
            PopUp = GameObject.Instantiate(gameObject);
        }
    }
}
