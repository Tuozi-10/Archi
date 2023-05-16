using Addressables;
using Attributes;
using UI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class UIService : IUIService
    {
        [DependsOnService] private ISceneService _sceneService;
        [DependsOnService] private IFightService _fightService;
        [DependsOnService] private IEntitiesFactoryService _entitiesFactoryService;
        [DependsOnService] private IEventService _eventService;

        private GameObject _mainMenu;
        private GameObject _popupMenu;
        private GameObject _inGameMenu;
        private bool isLoading;

        public void DisplayMainMenu()
        {
            if (isLoading) return;
            if (_mainMenu != null) _mainMenu.SetActive(true);
            else AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeCanvas", AssignMainMenu);
        }

        public void CallPopup()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LePopup", AssignPopupMenu);
        }

        public void DisplayInGameMenu()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameMenu", AssignInGameMenu);
        }

        private void AssignPopupMenu(GameObject gameObject)
        {
            isLoading = false;
            _popupMenu = Object.Instantiate(gameObject);
            _popupMenu.GetComponent<PopupManager>().Setup();
        }

        private void AssignMainMenu(GameObject gameObject)
        {
            isLoading = false;
            _mainMenu = Object.Instantiate(gameObject);
            _mainMenu.GetComponent<MenuManager>().Setup(_sceneService, _fightService, this);
        }

        private void AssignInGameMenu(GameObject gameObject)
        {
            isLoading = false;
            _inGameMenu = Object.Instantiate(gameObject);
            _inGameMenu.GetComponent<InGameMenuManager>().Setup(_eventService);
            Release(gameObject);
        }
    }
}