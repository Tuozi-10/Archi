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
            var createUnit0 = new UnitCreatedEvent(0);
            var createUnit1 = new UnitCreatedEvent(1);
            var createUnit2 = new UnitCreatedEvent(2);
            
            uiElements.GetButton(0).onClick.AddListener(()=>EventManager.Trigger(createUnit0));
            uiElements.GetButton(1).onClick.AddListener(()=>EventManager.Trigger(createUnit1));
            uiElements.GetButton(2).onClick.AddListener(()=>EventManager.Trigger(createUnit2));
            
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

public class UnitCreatedEvent
{
    public int Id { get; private set; }
    public UnitCreatedEvent(int id)
    {
        Id = id;
    }
}


