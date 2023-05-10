using System.Linq;
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

        public MoveToTargetComponent(Transform mover, NavMeshAgent agent, IFightService fightService, Transform target = null)
        {
            _mover = mover;
            _agent = agent;
            _fightService = fightService;
            if (target is not null)
            {
                SetTarget(target);
            }
            else
            {
                SetClosestTarget();
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _agent.SetDestination(_target.position);
        }

        public void SetClosestTarget()
        {
            _target = _fightService.GetClosestTree(_mover.transform.position);
            _agent.SetDestination(_target.position);
        }

        public void SetRandomTarget()
        {
            var random = Random.Range(0, _fightService.GetTrees().Count-1);
            _target = _fightService.GetTrees()[random].transform;
            _agent.SetDestination(_target.position);
        }

        public void Init() { }

        public void Update() { }
    }
}