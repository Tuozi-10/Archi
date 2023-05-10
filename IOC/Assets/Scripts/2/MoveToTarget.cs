using UnityEngine;

namespace _2
{
    public class MoveToTargetComponent : IComponent
    {
        private Transform m_target;

        public MoveToTargetComponent(Transform target = null)
        {
            if (target is not null)
            {
                SetTarget(target);
            }
        }
        
        public void SetTarget(Transform target)
        {
            m_target = target;
        }
        
        public void Init()
        {
            // define target
        }
        
        public void Update()
        {
            // move to target
        }

 
    }
}