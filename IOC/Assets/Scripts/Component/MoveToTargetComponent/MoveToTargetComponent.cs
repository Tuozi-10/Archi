using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public class MoveToTargetComponent : Component
    {
        private NavMeshAgent _agent;
        private Transform _destination;
        private float _speed;
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            _agent = (NavMeshAgent)entity.AllMonoComponents[EntityMonoComponentEnum.Agent];
            _speed = ((MoveToTargetComponentData)args[0]).Speed;
            _destination = (Transform)((Entity)args[1]).AllMonoComponents[EntityMonoComponentEnum.Transform];
        }

        protected override void Enable()
        {
            base.Enable();
            _agent.speed = _speed;
        }

        public void MoveToTarget()
        {
            _agent.SetDestination(_destination.position);
        }
    }
    
}