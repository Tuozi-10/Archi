using Entities.Resources;
using Entities.Workers;
using UnityEngine;

namespace DesignPatterns
{
    public class HarvesterBehaviour : StateMachineComponent
    {
        private float _timer;
        
        public HarvesterBehaviour(Worker owner) : base(owner) { }
        
        public override void Init()
        {
            ChangeState(States.HARVEST);
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
                if (resource is not null && resource.TypeResource == TypeResource.Stone && resource.Quantity > 0)
                {
                    resource.Quantity--;
                }
                else if (resource is not null && resource.TypeResource == TypeResource.Stone && resource.Quantity == 0)
                {
                    Worker.GetComponent<MoveToTargetComponent>().SetRandomTarget();
                }
            }
            _timer = 0;
        }
    }
}