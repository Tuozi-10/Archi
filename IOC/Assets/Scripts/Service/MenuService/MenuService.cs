using Addressables;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.MenuService
{
    public class MenuService : IMenuService
    {
        private GameObject menuGo;
        
        public void LoadMenu()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("MenuUI", LoadMenuPrefab);
        }
        
        private void LoadMenuPrefab(GameObject prefab)
        {
            menuGo = prefab;
            Object.Instantiate(menuGo);
            Release(prefab);
        }
    }
}


