using System.Collections.Generic;
using Addressables;
using Attributes;
using UI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.UIService
{
    public class UIService : SwitchableService, IUIService
    {
        private MainMenuManager mainMenuManager;
        private Queue<PopUp> popUps;

        [ServiceInit]
        private void Initialize()
        {
            popUps = new Queue<PopUp>();
        }

        private void GenerateInGameCanvas(GameObject canvas)
        {
            var inGameCanvas = Object.Instantiate(canvas);
            mainMenuManager = inGameCanvas.GetComponent<MainMenuManager>();
            mainMenuManager.AssignService(this);
            mainMenuManager.GeneratePopUps();
            Release(canvas);
        }

        public override void Enable()
        {
            if (mainMenuManager) mainMenuManager.Enable();
            else
                AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameCanvas", GenerateInGameCanvas);
        }

        public override void Disable()
        {
            if (mainMenuManager) mainMenuManager.Disable();
        }

        public void AddPopUpToQueue(PopUp popUp)
        {
            Debug.Log("Enqueuing");
            popUps.Enqueue(popUp);
            DisplayNextPopUp();
        }

        public void DisplayNextPopUp()
        {
            Debug.Log(popUps.Count);

            if (popUps.Count == 0)
            {
                Debug.LogWarning("There's no pop-up to display!");
                return;
            }

            if (mainMenuManager.currentPopUp)
            {
                Debug.LogWarning("There's already a pop-up displayed");
                return;
            }
            var popUp = popUps.Dequeue();
            mainMenuManager.DisplayPopUp(popUp);
        }
    }
}