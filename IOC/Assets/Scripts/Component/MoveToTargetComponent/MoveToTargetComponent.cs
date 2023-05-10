using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public class MoveToTargetComponent : Component
    {
        private NavMeshAgent agent;
        
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            agent = (NavMeshAgent)entity.AllMonoComponents[EntityMonoComponentEnum.Agent];
            agent.speed = ((MoveToTargetComponentData)args[0]).Speed;
          
        }

        public void MoveToTarget(Vector3 dest)
        {
            agent.SetDestination(dest);
        }
    }
    
}