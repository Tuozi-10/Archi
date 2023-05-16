using Addressables;
using Attributes;
using Components;
using Events;
using UnityEngine;


namespace Service
{
    //providers groupement de référence àdes services
    public class FightService : IFightService
    {
        [DependsOnService] private IBuildingFactoryService _buildingFactoryService;
        [DependsOnService] private IRessourceFactoryService _ressourceFactoryService;
        [DependsOnService] private IAgentFactoryService _agentFactoryService;
        [DependsOnService] private IUICanvasSwitchableService canvasSwitchableService;
        private const string _mainCameraAdressableName = "GameCamera";
        private const string _groundAdressableName = "Ground";
        private Camera mainCamera;
        private GameObject ground;
        private Entity _hub;
        private Entity _tree;
        private Entity _agent;

        public void StartFight()
        {
            EventManagerSingleton.Get(   (EventManagerSingleton)=>
            {
                canvasSwitchableService.LoadInGameMenu(() =>
                    _ressourceFactoryService.EnabledService(LoadBuildingFactoryService));
            });
       
        }

        public Entity GetHub()
        {
            return _hub;
        }

        public Entity GetClosestRessource()
        {
            return _tree;
        }

        void LoadBuildingFactoryService()
        {
            _buildingFactoryService.EnabledService(LoadAgentFactoryService);
        }

        void LoadAgentFactoryService()
        {
            _agentFactoryService.EnabledService(LoadCamera);
        }

        void LoadCamera()
        {
            //  eventService.AddListener<LumberjackCreatedEvent>(GetLumberjack);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_mainCameraAdressableName,
                InitCamera);
        }

        void InitCamera(GameObject cameraPrefab)
        {
            mainCamera = Object.Instantiate(cameraPrefab).GetComponent<Camera>();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_groundAdressableName, InitGround);
        }
        /*

        void GetLumberjack(LumberjackCreatedEvent lumberjackCreatedEvent)
        {
            _agent = lumberjackCreatedEvent.Lumberjack;
            Debug.Log(_agent.name);
        }
        */

        void InitGround(GameObject groundPrefab)
        {
            ground = Object.Instantiate(groundPrefab);
            _hub = _buildingFactoryService.CreateHub(Vector3.zero);
            _tree = _ressourceFactoryService.CreateTree(Vector3.left * 20);
            _agentFactoryService.CreateLumberjack(Vector3.back * 10);
            //   eventService.Trigger(new NeedCreateLumberJackEvent(Vector3.back * 10));
            //  eventService.AddListener(new IEventService.EventCallback<TestEvent>(DebugEvent));
            //  eventService.Trigger(new TestEvent(5));
        }
    }
}