using Service;
using UnityEngine;
using UnityEngine.AI;

namespace DesignPatterns
{
    public class MoveToTargetComponent : IComponent
    {
        private IEntitiesFactoryService _entitiesFactoryService;
        private NavMeshAgent _agent;
        private Transform _worker;
        private Transform _target;
        private TypeResource _typeResource;

        public MoveToTargetComponent(Transform worker, NavMeshAgent agent, IEntitiesFactoryService entitiesFactoryService, TypeResource typeResource)
        {
            _worker = worker;
            _agent = agent;
            _entitiesFactoryService = entitiesFactoryService;
            _typeResource = typeResource;
            SetClosestTarget();
        }

        public void Init() { }

        public void Update() { }

        public void SetTarget(Transform target = null)
        {
            _target = target;
            if (_target is not null) _agent.SetDestination(_target.position);
        }

        public void SetClosestTarget()
        {
            if (_typeResource == TypeResource.Tree) _target = _entitiesFactoryService.GetClosestTree(_worker.transform.position);
            else if (_typeResource == TypeResource.Stone) _target = _entitiesFactoryService.GetClosestStone(_worker.transform.position);
            _agent.SetDestination(_target.position);
        }

        public void SetRandomTarget()
        {
            int random;
            if (_typeResource == TypeResource.Tree)
            {
                random = Random.Range(0, _entitiesFactoryService.GetTrees().Count-1);
                _target = _entitiesFactoryService.GetTrees()[random].transform;
            }
            else if (_typeResource == TypeResource.Stone)
            {
                random = Random.Range(0, _entitiesFactoryService.GetStones().Count-1);
                _target = _entitiesFactoryService.GetStones()[random].transform;
            }
            
            _agent.SetDestination(_target.position);
        }
    }

    public enum TypeResource
    {
        Tree,
        Stone
    }
}