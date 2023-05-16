using System;
using entities;
using UnityEngine;
using UnityEngine.AI;

namespace Dp.DesignPatterns
{
    public class MoveToTargetComponent : IComponent
    {
        private Transform m_target;
        private NavMeshAgent agent;
        private Entity entity;

        public MoveToTargetComponent(Entity entity)
        {
            this.entity = entity;
            agent = entity.gameObject.AddComponent<NavMeshAgent>();
        }

        public void SetTarget(Transform target)
        {
            m_target = target;
        }

        public void Init() { }

        public void Update() { }

        public bool MoveToPoint()
        {
            if (DistanceToTarget() < 1f)
            {
                return true;
            }

            agent.SetDestination(m_target.position);
            return false;
        }

        private float DistanceToTarget()
        {
            return Vector3.Distance(entity.transform.position, m_target.position);
        }
    }
}