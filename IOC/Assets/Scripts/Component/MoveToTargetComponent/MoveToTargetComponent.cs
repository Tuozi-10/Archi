using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public class MoveToTargetComponent : Component
    {
        private Transform currentTransform;
        
        public Transform Destination { private get; set; }
        public float Time { private get;  set; }
        public void Init(Entity entity, MoveToTargetComponentData moveToTargetComponentData, Entity target)
        {
            Init(entity);
            currentTransform =(Transform) entity.AllMonoComponents[EntityMonoComponentEnum.Transform];
            Time = moveToTargetComponentData.Time;
            Destination = (Transform)target.AllMonoComponents[EntityMonoComponentEnum.Transform];
        }
        
        

        protected override void Enable()
        {
            base.Enable();
            
        }

        public void MoveToTarget()
        {
            currentTransform.DOMove( Destination.position, Time);
        }
    }
    
}