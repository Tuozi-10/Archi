using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Components;
using UnityEngine;
using UnityEngine.AI;

namespace Service
{
    public class FightService : IFightService
    {
        [DependsOnService] private IBuildingFactoryService _buildingFactoryService;
        [DependsOnService] private IRessourceFactoryService _ressourceFactoryService;
        [DependsOnService] private IAgentFactoryService _agentFactoryService;
        private const string _mainCameraAdressableName = "GameCamera";
        private const string _groundAdressableName = "Ground";
        private Camera mainCamera;
        private GameObject ground;
        private Entity _hub;
        private Entity _tree;

        public void StartFight()
        {
            _ressourceFactoryService.EnabledService(LoadBuildingFactoryService);
         
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
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_mainCameraAdressableName,
                InitCamera);
        }
        void InitCamera(GameObject cameraPrefab)
        {
            mainCamera = Object.Instantiate(cameraPrefab).GetComponent<Camera>();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(_groundAdressableName, InitGround);
        }

        void InitGround(GameObject groundPrefab)
        {
            ground = Object.Instantiate(groundPrefab);
           _hub=  _buildingFactoryService.CreateHub(Vector3.zero);
           _tree= _ressourceFactoryService.CreateTree(Vector3.left * 20);
           _agentFactoryService.CreateLumberjack(Vector3.back * 10);


        }
    }
}