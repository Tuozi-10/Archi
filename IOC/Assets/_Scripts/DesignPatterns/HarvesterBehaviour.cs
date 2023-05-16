using Entities.Workers;

namespace DesignPatterns
{
    public class HarvesterBehaviour : StateMachineComponent
    {
        public HarvesterBehaviour(Worker owner) : base(owner) { }
        
        public override void Init()
        {
            ChangeState(States.HARVEST);
        }

        protected override void DoHarvest()
        {
            base.DoHarvest();
        }
    }
}