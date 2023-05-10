using DefaultNamespace;
using entities;

namespace Dp.DesignPatterns
{
    public class LumberjackBehaviour : StateMachineComponent
    {
        
        public LumberjackBehaviour(Entity owner) : base(owner)
        {
        }
        
        public override void Init()
        {
            ChangeState(states.harvest);
        }

        protected override void DoHarvest()
        {
            base.DoHarvest();
            if (m_entity) // is full, for example, todo true logic
            {
                // todo go deposit
            }
        }
    }
}