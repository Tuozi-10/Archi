using UnityEngine;

namespace _2
{
    public class ForgerBehaviour : StateMachineComponent
    {
        private GameObject hub;
        private GameObject forgeParent;
        public ForgerBehaviour(Entity owner) : base(owner) { }
        
        public override void Init()
        {
            ChangeState(States.harvest);
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
