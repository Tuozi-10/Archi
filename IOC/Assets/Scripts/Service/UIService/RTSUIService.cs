using Addressables;
using Attributes;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.UIService
{
    public class RTSUIService : IUIService
    {
        [DependsOnService] private IGameService gameService;
        
        public Transform staticCanvas { get; }
        public Transform updateCanvas { get; private set; }

        private UIRTS uiElements;
        
        [ServiceInit]
        public void LoadUI()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("RTSCanvas",LinkUI);

            void LinkUI(GameObject obj)
            {
                updateCanvas = Object.Instantiate(obj).transform;
                Release(obj);

                uiElements = updateCanvas.GetComponent<UIRTS>();
                
                SetEvents();
            }
        }

        private void SetEvents()
        {
            gameService.OnResourceUpdated += UpdateResourceCount;

            int resourceIndex = 0;
            uiElements.GetButton(0).onClick.AddListener(()=>gameService.SpawnUnit(0));
            uiElements.GetButton(1).onClick.AddListener(()=>gameService.SpawnUnit(1));
            uiElements.GetButton(2).onClick.AddListener(ChangeResourceIndex);
            
            void UpdateResourceCount(int index,int amount)
            {
                uiElements.GetText(index).text = $"{amount}";
            }

            void ChangeResourceIndex()
            {
                resourceIndex++;
                if (resourceIndex >= 3)
                {
                    resourceIndex = 0;
                }
            }
            
        }
    }
}


