using Addressables;
using Attributes;
using Service.AudioService;
using Service.FightService;
using Service.SceneService;
using Service.TickableService;
using Service.UIService;
using UI;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.UIService
{
    public class UIService : SwitchableService, IUIService
    {
        private MainMenuManager mainMenuManager;

        [ServiceInit]
        private void Initialize() { }

        private void GenerateInGameCanvas(GameObject canvas)
        {
            var inGameCanvas = Object.Instantiate(canvas);
            mainMenuManager = inGameCanvas.GetComponent<MainMenuManager>();
            mainMenuManager.AssignService(this);
            Release(canvas);
        }

        public override void Enable()
        {
            if(mainMenuManager) mainMenuManager.Enable();
            else AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameCanvas", GenerateInGameCanvas);
        }

        public override void Disable()
        {
            if(mainMenuManager) mainMenuManager.Disable();
        }
    }
}