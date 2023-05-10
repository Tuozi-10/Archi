using System;
using Addressables;
using Attributes;
using UnityEditor.AI;
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
        private int[] resources;
        public int GetResources(int index) => index >= resources.Length || index < 0 ? resources[0] : resources[index];
        
        public event Action<int, int> OnResourceUpdated;

        private static EntityLocation entityLocation;
        public static Structure GetStructure(int index) => entityLocation.GetStructure(index);

        [ServiceInit]
        private void Init()
        {
            StartLoadingAssets();
        }

        //[OnTick]
        private void Update()
        {
            GenerateMissingUnits();
        }

        private void GenerateMissingUnits()
        {
            for (int i = 0; i < targetResources.Length; i++)
            {
                if (resources[i] < targetResources[i])
                {
                    
                }
            }
        }

        private void StartLoadingAssets()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("RTSMap",OnMapLoad);

            void OnMapLoad(GameObject mapAsset)
            {
                var map = Object.Instantiate(mapAsset);
                Release(mapAsset);
                
                NavMeshBuilder.BuildNavMesh();

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
            
        }

        private void InitResources()
        {
            resources = new int[3];
            for (int i = 0; i < resources.Length; i++)
            {
                UpdateResources(i,0);
            }
        }

        public void IncreaseResources(int index,int amount)
        {
            if(index >= resources.Length || index < 0) index = 0;
            UpdateResources(index,resources[index]+amount);
        }

        public void DecreaseResources(int index,int amount)
        {
            if(index >= resources.Length || index < 0) index = 0;
            UpdateResources(index,resources[index]-amount);
        }

        public void UpdateResources(int index,int amount)
        {
            if(index >= resources.Length || index < 0) index = 0;
            resources[index] = amount;
            OnResourceUpdated?.Invoke(index,amount);
        }

        public void SpawnUnit(int index)
        {
            var unit = factoryService.CreateGatherUnit(Vector3.zero, index);
            unit.GetComponent<UnitStateMachine>().Init();
        }
    }
}


