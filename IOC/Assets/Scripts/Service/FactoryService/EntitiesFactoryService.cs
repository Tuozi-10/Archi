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
            
            EventManager.AddListener<UnitCreatedEvent>(OnUnitCreated);

            void OnUnitCreated(UnitCreatedEvent data)
            {
                if (data.Id == 2)
                {
                    CreateForgerUnit(Vector3.zero);
                    return;
                }
                CreateGatherUnit(Vector3.zero, data.Id);
            }

            void AddUnitToList(ScriptableObject so)
            {
                unitData.Add(so as ScriptableUnitData);
            }
        }
        

        public Unit CreateGatherUnit(Vector3 position,int soIndex)
        {
            var unit = Object.Instantiate(unitPrefab, position, quaternion.identity).GetComponent<Unit>();
            var container = unit.AddComponent(new ResourceContainer(unitData[soIndex].TargetResource));
            unit.AddComponent(new GatherWorker(unit,unitData[soIndex],container));
            unit.GetComponent<UnitStateMachine>().Init();
            return unit;
        }
        
        public Unit CreateForgerUnit(Vector3 position)
        {
            var unit = Object.Instantiate(unitPrefab, position, quaternion.identity).GetComponent<Unit>();
            var container = unit.AddComponent(new ResourceContainer(unitData[2].TargetResource));
            unit.AddComponent(new ForgeWorker(unit,unitData[2],container,new ResourceContainer(0,0),new ResourceContainer(1,0)));
            unit.GetComponent<UnitStateMachine>().Init();
            return unit;
        }
        
        public Entity CreateEntity(Vector3 position,int soIndex)
        {
            return null;
        }
    }
}


