using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Components;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;

namespace Service
{
    public class AgentFactoryService : IAgentFactoryService
    {
        private AgentSO _lumberjackSO;
        private Entity _agentPrefab;
        private LoaderAdressable loaderAdressable;
        private int _currentLoad;

        private const string _agentAdressableName = "Agent";
        private const string _lumberjackSOAdressableName = "LumberJackSO";


        [ServiceInit]
        void Init()
        {
            loaderAdressable = new LoaderAdressable(2);
        }

        public void EnabledService(Action callback)
        {
            loaderAdressable.CurrentLoad = 0;
            loaderAdressable.TempEnabledCallback = callback;
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<AgentSO>(_lumberjackSOAdressableName,
                SetLumberjackSO);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_agentAdressableName, SetAgentPrefab);
        }

        private void SetLumberjackSO(AgentSO entitySo)
        {
            _lumberjackSO = entitySo;
            loaderAdressable.CheckAmountLoad();
        }

        private void SetAgentPrefab(GameObject entity)
        {
            _agentPrefab = entity.GetComponent<Entity>();
            loaderAdressable.CheckAmountLoad();
        }

        public void DisabledService(Action callback)
        {
            Release(_lumberjackSO);
            Release(_agentPrefab);
            callback?.Invoke();
        }

        public bool GetIsActiveService { get; }

        public Entity CreateHarvester(Vector3 pos)
        {
            throw new NotImplementedException();
        }

        public Entity CreateLumberjack(Vector3 pos)
        {
            var lumberjack = Object.Instantiate(_agentPrefab, pos, Quaternion.identity);
            lumberjack.Init();

            var dropTimeComponent = lumberjack.AddComponent(new TimerComponent());
            dropTimeComponent.Init(lumberjack, _lumberjackSO.DropTimeComponentData);

            var harvestTimeComponent = lumberjack.AddComponent(new TimerComponent());
            harvestTimeComponent.Init(lumberjack, _lumberjackSO.HarvestTimeComponentData);

            var ressourceComponent = lumberjack.AddComponent(new RessourceComponent());
            ressourceComponent.Init(lumberjack, _lumberjackSO.RessourceComponentData);

            var steelRessourceComponent = lumberjack.AddComponent(new SteelRessourceComponent());
            steelRessourceComponent.Init(lumberjack,
                _lumberjackSO.SteelRessourceComponentData, ressourceComponent);

            var dropRessourceComponent = lumberjack.AddComponent(new DropRessourceComponent());
            dropRessourceComponent.Init(lumberjack, ressourceComponent);
            var moveToRessourceComponent = lumberjack.AddComponent(new MoveToTargetComponent());
            moveToRessourceComponent.Init(lumberjack, _lumberjackSO.MoveToTargetComponentData);

            var moveToDropComponent = lumberjack.AddComponent(new MoveToTargetComponent());
            moveToDropComponent.Init(lumberjack, _lumberjackSO.MoveToTargetComponentData);
            
            
            var compareDistanceComponent = lumberjack.AddComponent(new CompareDistanceComponent());
         //  compareDistanceComponent.Init(lumberjack, );
            
            var agentBehaviour = lumberjack.AddComponent(new StateMachineComponent());
            var idle = new AgentIdleStateComponent();
            idle.Init(lumberjack, ressourceComponent);
            var harvest = new AgentHarvestStateComponent();
            harvest.Init(lumberjack, harvestTimeComponent, steelRessourceComponent);
            
            var drop = new AgentDropStateComponent();
            drop.Init(lumberjack, dropTimeComponent, dropRessourceComponent);
            /*
            var goToRessource = new AgentGoToRessourceStateComponent();
            goToRessource.Init(lumberjack, moveToTargetComponent, compareDistanceComponent );
            var goToDrop = new AgentGoToDropStateComponent(lumberjack, goto, compareDistanceComponent);
            agentBehaviour.Init(lumberjack, new StateComponent[]
                {

                }
            );
            lumberjack.AddComponent(new AgentDropStateComponent());
            */
            return lumberjack;
        }
    }
}