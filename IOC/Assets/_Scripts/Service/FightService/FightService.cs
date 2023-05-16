using Addressables;
using Attributes;
using UnityEditor.AI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class FightService : TickableSwitchableService, IFightService
    {
        [DependsOnService] private ISceneService _sceneService;
        [DependsOnService] private IUIService _uiService;
        [DependsOnService] private IEntitiesFactoryService _entitiesFactoryService;

        // private GameObject _burger;

        [ServiceInit]
        protected override void Initialize()
        {
            base.Initialize();
            Enable();
            
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<PersoSO>("LePerso", GeneratePerso);
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<PersoSO>("LeChamp", GeneratePerso);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            // if (_burger != null)
            // {
            //     _burger.transform.Rotate(Vector3.up, 1f);
            // }
        } 
        
        public override void Toggle()
        {
            base.Toggle();
            // if (_burger is not null)
            // {
            //     if (isActive) Enable();
            //     else Disable();
            // }
        }

        public override void Enable()
        {
            base.Enable();
            // if (_burger is not null) _burger.gameObject.SetActive(true);
        }

        public override void Disable()
        {
            base.Disable();
            // if (_burger is not null) _burger.gameObject.SetActive(false);
        }

        public void InitializeGame()
        {
            _sceneService.LoadScene("SecondScene");
            _entitiesFactoryService.Initialize();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Plane", GeneratePlane);
        }

        private void GeneratePlane(GameObject gameObject)
        {
            var plane = Object.Instantiate(gameObject);
            plane.transform.position += new Vector3(0, -0.5f, 0);
            _uiService.DisplayInGameMenu();
            NavMeshBuilder.BuildNavMesh();
            
            Release(gameObject);
        }

        // private void GenerateBurger(GameObject burger)
        // {
        //     _burger = Object.Instantiate(burger);
        //     _burger.SetActive(isActive);
        // }
        //
        // private void GeneratePerso(PersoSO perso)
        // {
        //     var persoScriptable = perso;
        // }
    }
}
