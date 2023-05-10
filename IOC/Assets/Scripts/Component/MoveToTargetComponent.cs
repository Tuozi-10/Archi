using UnityEngine;
using UnityEngine.AI;

namespace Component
{
    public class MoveToTargetComponent : IComponent
    {
        private Transform m_currentTarget;
        private NavMeshAgent owner;
        private bool onDestination;
        
        public MoveToTargetComponent(NavMeshAgent owner = null, Transform target = null)
        {
            this.owner = owner;
            
            if (target != null) SetTarget(target);
        }

        public void SetTarget(Transform newTarget)
        {
            if(newTarget != null && m_currentTarget == newTarget) return;
            m_currentTarget = newTarget;
        }

        public Transform GetTarget()
        {
            if (m_currentTarget != null) return m_currentTarget;
            return null;
        }

        public void Init()
        {
        }

        public void Update()
        {
            if(m_currentTarget != null) owner.SetDestination(m_currentTarget.position);
        }
    }
}