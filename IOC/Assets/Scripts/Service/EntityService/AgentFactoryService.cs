using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Components;
using Events;
using Service.Event;
using UnityEngine;
using UnityEngine.AI;
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
        [DependsOnService] private IEventService eventService;

        private const string _agentAdressableName = "Agent";
        private const string _lumberjackSOAdressableName = "LumberJackSO";


        [DependsOnService] private IFightService _fightService;
        
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
            
        //    eventService.AddEvent<LumberjackCreatedEvent>();
          //  eventService.AddEvent<NeedCreateLumberJackEvent>();
            //eventService.AddListener<NeedCreateLumberJackEvent>(new IEventService.EventCallback<NeedCreateLumberJackEvent>(CreateLumberjack));
            
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
            var harvestTimeComponent = lumberjack.AddComponent(new TimerComponent());
            var ressourceComponent = lumberjack.AddComponent(new RessourceComponent());
            ressourceComponent.Init(lumberjack, _lumberjackSO.RessourceComponentData);
            
            var steelRessourceComponent = lumberjack.AddComponent(new SteelRessourceComponent());
            RessourceComponent ressourceComponentOfTree = _fightService.GetClosestRessource().GetComponent<RessourceComponent>();
            steelRessourceComponent.Init(lumberjack,
                _lumberjackSO.SteelRessourceComponentData, ressourceComponent,
                ressourceComponentOfTree);

            var dropRessourceComponent = lumberjack.AddComponent(new DropRessourceComponent());
            dropRessourceComponent.Init(lumberjack, ressourceComponent, _fightService.GetHub().GetComponent<RessourceComponent>());
            var moveToRessourceComponent = lumberjack.AddComponent(new MoveToTargetComponent());
            moveToRessourceComponent.Init(lumberjack, _lumberjackSO.MoveToTargetComponentData,
                _fightService.GetClosestRessource());

            var moveToDropComponent = lumberjack.AddComponent(new MoveToTargetComponent());
            moveToDropComponent.Init(lumberjack, _lumberjackSO.MoveToTargetComponentData,
                _fightService.GetHub());
            
            var compareDistanceRessource = lumberjack.AddComponent(new CompareDistanceComponent());
            compareDistanceRessource.Init(lumberjack, _lumberjackSO.DistanceComponentData,
                (Transform)lumberjack.AllMonoComponents[EntityMonoComponentEnum.Transform],
                (Transform)_fightService.GetClosestRessource().AllMonoComponents[EntityMonoComponentEnum.Transform]);
            
            var compareDistanceDrop = lumberjack.AddComponent(new CompareDistanceComponent());
            compareDistanceDrop.Init(lumberjack, _lumberjackSO.DistanceComponentData,
                (Transform)lumberjack.AllMonoComponents[EntityMonoComponentEnum.Transform],
                (Transform)_fightService.GetHub().AllMonoComponents[EntityMonoComponentEnum.Transform]);

            
            var agentBehaviour = lumberjack.AddComponent(new StateMachineComponent());
            var idle =  lumberjack.AddComponent(new AgentIdleStateComponent());
            idle.Init(lumberjack, agentBehaviour,ressourceComponentOfTree);
            var harvest =   lumberjack.AddComponent(new AgentHarvestStateComponent());
            harvest.Init(lumberjack,agentBehaviour, harvestTimeComponent, steelRessourceComponent);

            var drop =  lumberjack.AddComponent( new AgentDropStateComponent());
            drop.Init(lumberjack, agentBehaviour, dropTimeComponent, dropRessourceComponent);

            dropTimeComponent.Init(lumberjack, _lumberjackSO.DropTimeComponentData, drop.EndDrop);

            harvestTimeComponent.Init(lumberjack, _lumberjackSO.HarvestTimeComponentData,harvest.EndHarvest);
            
            var goToRessource =  lumberjack.AddComponent(new AgentGoToRessourceStateComponent());
            goToRessource.Init(lumberjack,agentBehaviour, moveToRessourceComponent,  compareDistanceRessource);
            var goToDrop =  lumberjack.AddComponent(new AgentGoToDropStateComponent());
            goToDrop.Init(lumberjack, agentBehaviour, moveToDropComponent,  compareDistanceDrop);
            agentBehaviour.Init(lumberjack, new StateComponent[]
                {
                    idle, harvest, drop, goToRessource, goToDrop
                }, _lumberjackSO.StateMachineComponentData
            );
            lumberjack.AddComponent(new AgentDropStateComponent());
          
           // eventService.Trigger<LumberjackCreatedEvent>(new LumberjackCreatedEvent(lumberjack));
           EventManagerSingleton.Get(TriggerCallback);
           Debug.Log("test");
           return lumberjack;
        }

        void TriggerCallback(EventManagerSingleton eventManagerSingleton)
        {
            Debug.Log("testaa");
            eventManagerSingleton.Trigger(new OnAgentCreatedEvent());
        }
    }
}