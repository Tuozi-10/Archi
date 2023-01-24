using Addressables;
using Attributes;
using UnityEngine;

namespace Service
{
    public class UIService : IUIService
    {
        private GameObject mainMenu;
        private GameObject popupMenu; 
        private bool isLoading;
        [DependsOnService]
        private ISceneService m_sceneService;
        [DependsOnService]
        private IFightService m_fightService;
        
        public void DisplayMainMenu()
        {
            if (isLoading) return;
            if (mainMenu != null) mainMenu.SetActive(true);
            else AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeCanvas", AssignMainMenu);
        }

        public void CallPopup()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LePopup", AssignPopupMenu);
        }

        private void AssignPopupMenu(GameObject gameObject)
        {
            isLoading = false;
            popupMenu = Object.Instantiate(gameObject);
            popupMenu.GetComponent<PopupManager>().Setup();
        }

        private void AssignMainMenu(GameObject gameObject)
        {
            isLoading = false;
            mainMenu = Object.Instantiate(gameObject);
            mainMenu.GetComponent<MenuManager>().Setup(m_sceneService, m_fightService);
        }
    }
}