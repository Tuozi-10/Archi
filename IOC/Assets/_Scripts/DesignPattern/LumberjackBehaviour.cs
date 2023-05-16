using Entities;

namespace DesignPattern
{
    public class LumberjackBehaviour : StateMachineComponent
    {
        private MoveToTargetComponent _moveToTargetComponent;
        
        public LumberjackBehaviour(Entity owner) : base(owner)
        {
            _moveToTargetComponent = _entity.GetComponent<MoveToTargetComponent>() as MoveToTargetComponent;
        }
        
        public override void Init()
        {
            ChangeState(States.IDLE);
        }

        protected override void ChangeToIdle()
        {
            base.ChangeToIdle();
            ChangeState(States.WANDER);
        }

        protected override void DoIdle()
        {
            base.DoIdle();
        }

        protected override void DoWander()
        {
            base.DoWander();
            ChangeState(States.HARVEST);
        }

        protected override void DoHarvest()
        {
            base.DoHarvest();
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