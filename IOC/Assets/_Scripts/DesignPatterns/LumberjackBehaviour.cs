using Entities.Resources;
using Entities.Workers;
using UnityEngine;

namespace DesignPatterns
{
    public class LumberjackBehaviour : StateMachineComponent
    {
        private float _timer;
        
        public LumberjackBehaviour(Worker owner) : base(owner) { }
        
        public override void Init()
        {
            ChangeState(States.HARVEST);
        }

        protected override void DoIdle()
        {
            base.DoIdle();
            ChangeState(States.WANDER);
        }

        protected override void DoWander()
        {
            base.DoWander();
            ChangeState(States.WANDER);
        }

        protected override void DoHarvest()
        {
            base.DoHarvest();
            _timer += Time.deltaTime;
            if (Worker.Data.HarvestTime > _timer) return;
            Collider[] hitColliders = Physics.OverlapSphere(Worker.gameObject.transform.position, 2);
            foreach (var collider in hitColliders)
            {
                var resource = (Resource)collider.GetComponent(typeof(Resource));
                if (resource is not null && resource.TypeResource == TypeResource.Tree && resource.Quantity > 0)
                {
                    resource.Quantity--;
                }
                else if (resource is not null && resource.TypeResource == TypeResource.Tree && resource.Quantity == 0)
                {
                    Worker.GetComponent<MoveToTargetComponent>().SetRandomTarget();
                }
            }
            _timer = 0;
        }

        protected override void DoDeposit()
        {
            base.DoDeposit();
        }

        protected override void DoCraft()
        {
            base.DoCraft();
        }
    }
}