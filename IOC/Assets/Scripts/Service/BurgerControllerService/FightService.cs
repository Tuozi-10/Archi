using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace Service
{
    public class FightService : IFightService
    {
        [DependsOnService] private IBuildingFactoryService _buildingFactoryService;
        [DependsOnService] private IRessourceFactoryService _ressourceFactoryService;
        private const string _mainCameraAdressableName = "GameCamera";
        private const string _groundAdressableName = "Ground";
        private Camera mainCamera;
        private GameObject ground;

        public void StartFight()
        {
            _ressourceFactoryService.EnabledService(LoadBuildingFactoryService);
         
        }

        void LoadBuildingFactoryService()
        {
            _buildingFactoryService.EnabledService(LoadCamera);
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
            _buildingFactoryService.CreateHub(Vector3.zero);
            _ressourceFactoryService.CreateTree(Vector3.left * 20);
            
        }
    }
}