using System.Collections.Generic;
using Addressables;
using Attributes;
using DesignPatterns;
using Entities.Resources;
using Entities.Workers;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.AddressableAssets.Addressables;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

namespace Service
{
    public class EntitiesFactoryService : IEntitiesFactoryService
    {
        [DependsOnService] private IFightService _fightService;

        private WorkerSO _lumberjack;
        private WorkerSO _harvester;
        private ResourceSO _tree;
        private ResourceSO _stone;

        private Pool<GameObject> _poolLumberjack;
        private Pool<GameObject> _poolHarvester;
        
        public List<GameObject> Trees = new();
        public List<GameObject> Stones = new();

        private Pool<GameObject> _poolTree;
        private Pool<GameObject> _poolStone;

        public void Initialize()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<WorkerSO>("Lumberjack", GenerateLumberjack);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<WorkerSO>("Harvester", GenerateHarvester);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ResourceSO>("Tree", GenerateTree);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ResourceSO>("Stone", GenerateStone);
        }

        public void CreateHarvester()
        {
            var harvester = _poolHarvester.GetFromPool();
            harvester.AddComponent<NavMeshAgent>();
            var agent = harvester.GetComponent<NavMeshAgent>();
            var entity = harvester.GetComponent<Worker>();
            entity.AddComponent(
                new MoveToTargetComponent(harvester.transform, agent, this, TypeResource.Stone));
            entity.AddComponent(new LumberjackBehaviour(entity));
        }

        public void CreateLumberjack()
        {
            var lumberjack = _poolLumberjack.GetFromPool();
            lumberjack.AddComponent<NavMeshAgent>();
            var agent = lumberjack.GetComponent<NavMeshAgent>();
            var entity = lumberjack.GetComponent<Worker>();
            entity.AddComponent(
                new MoveToTargetComponent(lumberjack.transform, agent, this, TypeResource.Tree));
            entity.AddComponent(new LumberjackBehaviour(entity));
        }
        
        public void CreateTrees()
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

        public void CreateStones()
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

        public void CreateEntityEvent(CreateEvent createEvent)
        {
            switch (createEvent.TypeWorker)
            {
                case TypeWorker.HARVESTER:
                    CreateHarvester();
                    break;
                case TypeWorker.LUMBERJACK:
                    CreateLumberjack();
                    break;
            }
            
        }

        private void GenerateHarvester(WorkerSO harvester)
        {
            _harvester = harvester;
            _poolHarvester = new Pool<GameObject>(_harvester.PrefabWorker);
            Release(harvester);
        }

        private void GenerateLumberjack(WorkerSO lumberjack)
        {
            _lumberjack = lumberjack;
            _poolLumberjack = new Pool<GameObject>(_lumberjack.PrefabWorker);
            Release(lumberjack);
        }
        
        private void GenerateTree(ResourceSO tree)
        {
            _tree = tree;
            _poolTree = new Pool<GameObject>(_tree.PrefabResource);
            CreateTrees();
            Release(tree);
        }
        
        private void GenerateStone(ResourceSO stone)
        {
            _stone = stone;
            _poolStone = new Pool<GameObject>(_stone.PrefabResource);
            CreateStones();
            Release(stone);
        }
    }
}