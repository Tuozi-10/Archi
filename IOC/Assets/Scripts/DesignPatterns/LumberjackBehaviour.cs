using DefaultNamespace;
using entities;

namespace Dp.DesignPatterns
{
    public class LumberjackBehaviour : StateMachineComponent
    {
        private MoveToTargetComponent _moveToTargetComponent;
        private ResourceFinderComponent _resourceFinderComponent;

        public LumberjackBehaviour(Entity owner) : base(owner)
        {
            _moveToTargetComponent = owner.GetCompositeComponent<MoveToTargetComponent>();
            _resourceFinderComponent = owner.GetCompositeComponent<ResourceFinderComponent>();
        }

        public override void Init()
        {
            ChangeState(states.harvest);
        }

        protected override void ChangeToHarvestCompleted() { }

        protected override void ChangeToIdle() { }

        protected override void ChangeToHarvest() { }

        protected override void ChangeToCraft() { }

        protected override void ChangeToStock() { }

        protected override void DoHarvestCompleted() { }

        protected override void DoIdle() { }

        protected override void DoHarvest() { }

        protected override void DoCraft() { }
        
        protected override void DoStock() { }
    }
}