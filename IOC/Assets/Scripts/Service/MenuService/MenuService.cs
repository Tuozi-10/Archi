using Addressables;
using Attributes;
using Service.SceneService;
using UI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class MenuService : IMenuService
    {
        [DependsOnService]
        private ISceneService sceneService;
        
        private GameObject menuGo;
        private UIMenu uiMenu;
        
        public void LoadMenu()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("MenuUI", LoadMenuPrefab);
        }
        
        private void LoadMenuPrefab(GameObject prefab)
        {
            menuGo = prefab;
            uiMenu = Object.Instantiate(menuGo).GetComponent<UIMenu>();

            //uiMenu.playButton.onClick.AddListener(() => sceneService.LoadScene(1));
            
            Release(prefab);
        }
    }
}


