using System;
using Addressables;
using Attributes;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;

namespace Service
{
    public class RTSService : IGameService
    {
        [DependsOnService] private IEntitiesFactoryService factoryService;

        private UIRTS ui;

        private int[] targetResources = { 3, 3, 6 };
        public event Action<int, int> OnResourceUpdated;

        private static EntityLocation entityLocation;
        public static Structure GetStructure(int index) => entityLocation.GetStructure(index);

        [ServiceInit]
        private void Init()
        {
            StartLoadingAssets();
        }
        
        private void StartLoadingAssets()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("RTSMap",OnMapLoad);

            void OnMapLoad(GameObject mapAsset)
            {
                var map = Object.Instantiate(mapAsset);
                Release(mapAsset);

                entityLocation = map.GetComponent<EntityLocation>();
                
                InitGame();
            }
        }

        private void InitGame()
        {
            LinkStructures();
            
            InitResources();
        }

        private void LinkStructures()
        {
            var hubWoodContainer = new ResourceContainer(0, 0);
            var hubRockContainer = new ResourceContainer(1, 0);
            var stockContainer = new ResourceContainer(2, 0);
            
            ((HubStructure)GetStructure(0)).AssignContainers(hubWoodContainer,hubRockContainer);
            
            ((ResourceStructure)GetStructure(1)).AssignContainer(new ResourceContainer(0,100));
            ((ResourceStructure)GetStructure(2)).AssignContainer(new ResourceContainer(1,100));
            ((Forge)GetStructure(3)).AssignContainers(hubWoodContainer,2,hubRockContainer,2);
            ((ResourceStructure)GetStructure(4)).AssignContainer(stockContainer);

            EventManager.AddListener<ResourceContainerUpdatedEvent>(UpdateResource);
            
            void UpdateResource(ResourceContainerUpdatedEvent container)
            {
                if(container.Container == hubWoodContainer) UpdateResources(0,hubWoodContainer.amount);
                if(container.Container == hubRockContainer) UpdateResources(1,hubRockContainer.amount);
                if(container.Container == stockContainer) UpdateResources(2,stockContainer.amount);
            }
        }

        private void InitResources()
        {
            for (int i = 0; i < 3; i++)
            {
                UpdateResources(i,0);
            }
        }
        
        public void UpdateResources(int index,int amount)
        {
            OnResourceUpdated?.Invoke(index,amount);
        }
    }
}