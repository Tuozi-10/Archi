using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Components;
using Service;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;

namespace Service
{
    public class BuildingFactoryService : IBuildingFactoryService
    {
        private BuildingSO _hubSO;
        private Entity _hubPrefab;
        private LoaderAdressable loaderAdressable;
        private int _currentLoad;

        private const string _hubAdressableName = "Hub";
        private const string _hubSOAdressableName = "HubSO";

        public Entity CreateHub(Vector3 pos)
        {
            var hub = Object.Instantiate(_hubPrefab, pos, Quaternion.identity);
            hub.AddComponent(new RessourceComponent()).Init(hub, _hubSO.RessourceComponentData);
            hub.Init();
            return hub;
        }

        public Entity CreateForge(Vector3 pos)
        {
            throw new System.NotImplementedException();
        }

        public Entity CreateStock(Vector3 pos)
        {
            throw new System.NotImplementedException();
        }


        [ServiceInit]
        void Init()
        {
            loaderAdressable = new LoaderAdressable(2);
        }

        public void EnabledService(Action callback)
        {
            loaderAdressable.CurrentLoad = 0;
            loaderAdressable.TempEnabledCallback = callback;
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<BuildingSO>(_hubSOAdressableName, SetHubSO);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_hubAdressableName, SetHubPrefab);
        }

        private void SetHubSO(BuildingSO entitySo)
        {
            _hubSO = entitySo;
            loaderAdressable.CheckAmountLoad();
        }

        private void SetHubPrefab(GameObject entity)
        {
            _hubPrefab = entity.GetComponent<Entity>();
            loaderAdressable.CheckAmountLoad();
        }

        public void DisabledService(Action callback)
        {
            Release(_hubSO);
            Release(_hubPrefab);
            callback?.Invoke();
        }

        public bool GetIsActiveService { get; }
    }
}