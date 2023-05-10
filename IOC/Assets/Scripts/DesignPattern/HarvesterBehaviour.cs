using DefaultNamespace;

namespace DesignPattern
{
    public class HarvesterBehaviour : StateMachineComponent
    {
        public HarvesterBehaviour(Entity owner) : base(owner)
        {
            
        }
        
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