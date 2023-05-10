using System.Collections.Generic;
using Addressables;
using Attributes;
using Unity.Mathematics;
using UnityEngine;

namespace Service
{
    public class EntitiesFactoryService : IEntitiesFactoryService
    {
        private GameObject unitPrefab;

        private readonly List<ScriptableUnitData> unitData = new List<ScriptableUnitData>();
        
        [ServiceInit]
        public void LoadData()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("RTSUnit", (go) => unitPrefab = go);

            unitData.Clear();
            
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableObject>("WoodGathererSO",AddUnitToList);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableObject>("RockGathererSO",AddUnitToList);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableObject>("ForgerSO",AddUnitToList);

            void AddUnitToList(ScriptableObject so)
            {
                unitData.Add(so as ScriptableUnitData);
            }
        }
        

        public Unit CreateGatherUnit(Vector3 position,int soIndex)
        {
            var unit = Object.Instantiate(unitPrefab, position, quaternion.identity).GetComponent<Unit>();
            var container = unit.AddComponent(new ResourceContainer(unitData[soIndex].TargetResources[0]));
            unit.AddComponent(new GatherWorker(unit,unitData[soIndex],container));
            return unit;
        }
        
        public Entity CreateEntity(Vector3 position,int soIndex)
        {
            return null;
        }
    }
}


