using System;


namespace Components
{
    public  class StateMachineComponent : Component
    {
        public int CurrentState;
        public readonly Entity m_entity;

        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            
        }

        public void ChangeState(int newState)
        {
            
        }


    }
}

   