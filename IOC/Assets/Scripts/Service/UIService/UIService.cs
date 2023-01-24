using Addressables;
using Attributes;
using UnityEngine;

namespace Service
{
    public class UIService : IUIService
    {
        private GameObject mainMenu;
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

        private void AssignMainMenu(GameObject gameObject)
        {
            isLoading = false;
            mainMenu = Object.Instantiate(gameObject);
            mainMenu.GetComponent<MenuManager>().Setup(m_sceneService, m_fightService);
        }
    }
}