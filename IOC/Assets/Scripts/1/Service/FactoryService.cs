using System;
using Attributes;
using Service.UIService;
using UnityEngine;

namespace Service
{
    public class FactoryService : IFactoryService
    {
        public bool Active { get; set; }
        
        private GameObject hub, forgersParent, diggersParent, lumberjacksParent;
        private SOEntity forgerSo, diggerSo, lumberjackSo;
        private int poolSize = 10;

        [ServiceInit]
        private void Initialize()
        {
            hub = GameObject.Find("Hub");
            CreateParents();
            LoadSO();
            LoadPrefabs();
        }

        private void LoadPrefabs()
        {
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LumberJack", SpawnLumberjacks());
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Digger", SpawnDiggers());
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Forger", SpawnForgers());
        }

        private void LoadSO()
        {
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<SOEntity>("ForgerSO", obj =>
            {
                forgerSo = obj;
            });
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<SOEntity>("DiggerSO", obj =>
            {
                diggerSo = obj;
            });
            Addressables.AddressableHelper.LoadAssetAsyncWithCompletionHandler<SOEntity>("LumberjackSO", obj =>
            {
                lumberjackSo = obj;
            });
        }

        private void CreateParents()
        {
            diggersParent = new GameObject
            {
                name = "Diggers"
            };
            diggersParent.transform.SetParent(hub.transform);
            diggersParent.transform.position = new Vector3(0, 0, 0);
            
            forgersParent = new GameObject
            {
                name = "Forgers"
            };
            forgersParent.transform.SetParent(hub.transform);
            forgersParent.transform.position = new Vector3(0, 0, 0);
            
            lumberjacksParent = new GameObject
            {
                name = "Lumberjacks"
            };
            lumberjacksParent.transform.SetParent(hub.transform);
            lumberjacksParent.transform.position = new Vector3(0, 0, 0);
        }

        private Action<GameObject> SpawnForgers()
        {
            return obj =>
            {
                var forger = GameObject.Instantiate(obj);
                forger.transform.SetParent(forgersParent.transform);
                forger.transform.position = new Vector3(0, 0, 0);
            };
        }
        
        private Action<GameObject> SpawnDiggers()
        {
            
            return obj =>
            {
                var digger = GameObject.Instantiate(obj);
                digger.transform.SetParent(diggersParent.transform);
                digger.transform.position = new Vector3(0, 0, 0);
            };
        }
        
        private Action<GameObject> SpawnLumberjacks()
        {
            return obj =>
            {
                var lumberjack = GameObject.Instantiate(obj);
                lumberjack.transform.SetParent(lumberjacksParent.transform);
                lumberjack.transform.position = new Vector3(0, 0, 0);
            };
        }

        public void Toggle(bool active)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }
        
        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}