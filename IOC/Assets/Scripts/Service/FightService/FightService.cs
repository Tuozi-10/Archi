using System.Collections.Generic;
using Addressables;
using Attributes;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.AddressableAssets.Addressables;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace Service
{
    public class FightService : TickableSwitchableService, IFightService
    {
        [DependsOnService] private ISceneService _sceneService;
        [DependsOnService] private IUIService _uiService;

        public List<GameObject> Trees = new();
        public List<GameObject> Stones = new();

        private Pool<GameObject> _poolTree;
        private Pool<GameObject> _poolStone;

        // private GameObject _burger;


        [ServiceInit]
        protected override void Initialize()
        {
            base.Initialize();
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<PersoSO>("LePerso", GeneratePerso);
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<PersoSO>("LeChamp", GeneratePerso);
            Enable();
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

        public Transform GetClosestTree(Vector3 pos)
        {
            Transform treeToReturn = Trees[0].transform;
            var distance = Vector3.Distance(pos, Trees[0].transform.position);
            foreach (var tree in Trees)
            {
                if (distance > Vector3.Distance(pos, tree.transform.position))
                {
                    distance = Vector3.Distance(pos, tree.transform.position);
                    treeToReturn = tree.transform;
                }
            }

            return treeToReturn;
        }

        public Transform GetClosestStone(Vector3 pos)
        {
            Transform stoneToReturn = Stones[0].transform;
            var distance = Vector3.Distance(pos, Stones[0].transform.position);
            foreach (var tree in Stones)
            {
                if (distance > Vector3.Distance(pos, tree.transform.position))
                {
                    distance = Vector3.Distance(pos, tree.transform.position);
                    stoneToReturn = tree.transform;
                }
            }

            return stoneToReturn;
        }

        public List<GameObject> GetTrees()
        {
            return Trees;
        }

        public List<GameObject> GetStones()
        {
            return Stones;
        }

        public void InitializeGame()
        {
            _sceneService.LoadScene("SecondScene");
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Plane", GeneratePlane);
        }

        private void GeneratePlane(GameObject gameObject)
        {
            var plane = Object.Instantiate(gameObject);
            plane.transform.position += new Vector3(0, -0.5f, 0);
            _uiService.DisplayInGameMenu();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Tree", GenerateTree);
            Release(gameObject);
        }
        
        private void GenerateTree(GameObject gameObject)
        {
            _poolTree = new Pool<GameObject>(gameObject);
            InstantiateTree();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Stone", GenerateStone);
            Release(gameObject);
        }
        
        private void GenerateStone(GameObject gameObject)
        {
            _poolStone = new Pool<GameObject>(gameObject);
            InstantiateStone();
            Release(gameObject);
        }

        private void InstantiateTree()
        {
            var numberOfTrees = Random.Range(0, 100);
            for (int i = 0; i < numberOfTrees; i++)
            {
                var x = Random.Range(-50, 50);
                var z = Random.Range(-50, 50);
                var tree = _poolTree.GetFromPool();
                tree.transform.position = new Vector3(x, 0, z);
                Trees.Add(tree);
            }
        }

        private void InstantiateStone()
        {
            var numberOfStones = Random.Range(0, 100);
            for (int i = 0; i < numberOfStones; i++)
            {
                var x = Random.Range(-50, 50);
                var z = Random.Range(-50, 50);
                var stone = _poolStone.GetFromPool();
                stone.transform.position = new Vector3(x, 0, z);
                Stones.Add(stone);
            }
            NavMeshBuilder.BuildNavMesh();
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
