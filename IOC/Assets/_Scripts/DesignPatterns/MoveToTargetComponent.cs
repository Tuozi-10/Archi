using Service;
using UnityEngine;
using UnityEngine.AI;

namespace DesignPattern
{
    public class MoveToTargetComponent : IComponent
    {
        private Transform _mover;
        private Transform _target;
        private NavMeshAgent _agent;
        private IFightService _fightService;
        private TypeResource _typeResource;

        public MoveToTargetComponent(Transform mover, NavMeshAgent agent, IFightService fightService, TypeResource typeResource)
        {
            _mover = mover;
            _agent = agent;
            _fightService = fightService;
            _typeResource = typeResource;
            SetClosestTarget();
        }

        public void Init() { }

        public void Update() { }

        public void SetTarget(Transform target)
        {
            _target = target;
            _agent.SetDestination(_target.position);
        }

        public void SetClosestTarget()
        {
            if (_typeResource == TypeResource.Tree) _target = _fightService.GetClosestTree(_mover.transform.position);
            else if (_typeResource == TypeResource.Stone) _target = _fightService.GetClosestStone(_mover.transform.position);
            _agent.SetDestination(_target.position);
        }

        public void SetRandomTarget()
        {
            int random;
            if (_typeResource == TypeResource.Tree)
            {
                random = Random.Range(0, _fightService.GetTrees().Count-1);
                _target = _fightService.GetTrees()[random].transform;
            }
            else if (_typeResource == TypeResource.Stone)
            {
                random = Random.Range(0, _fightService.GetStones().Count-1);
                _target = _fightService.GetStones()[random].transform;
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