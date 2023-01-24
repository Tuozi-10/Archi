using Addressables;
using Attributes;
using Service.PopUpService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.UIService
{
    public class UIService : IUIService
    {
        //[DependsOnService]
        //private IMenuService menuService;

        [DependsOnService]
        private IPopUpService popUpService;
        
        public Transform staticCanvas { get; private set; }
        public Transform updateCanvas { get; private set; }

        public void LoadUI()
        {
            //menuService.LoadMenu();
            //AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("MenuUI", LoadCanvas);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Canvas", LoadCanvas);
        }

        private void LoadCanvas(GameObject asset)
        {
            staticCanvas = Object.Instantiate(asset).transform;
            updateCanvas = Object.Instantiate(asset).transform;
            Release(asset);
            
            popUpService.LoadPopUp();
        }
    }
}


