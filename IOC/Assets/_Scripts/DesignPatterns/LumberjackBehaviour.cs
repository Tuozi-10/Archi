using Entities.Workers;

namespace DesignPatterns
{
    public class LumberjackBehaviour : StateMachineComponent
    {
        public LumberjackBehaviour(Worker owner) : base(owner) { }
        
        public override void Init()
        {
            ChangeState(States.IDLE);
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