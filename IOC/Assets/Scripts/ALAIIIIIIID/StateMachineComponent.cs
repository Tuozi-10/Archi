using System;

public abstract class StateMachineComponent : IComponent
    {
        private states m_currentState = states.idle;  
        public readonly Entity m_entity;

        public StateMachineComponent(Entity owner)
        {
            m_entity = owner;
        }
        
        public virtual void Init()
        {
            m_currentState = states.wander;
        }
        
        public void Update()
        {
            UpdateStateMachine();
        }

        public void ChangeState(states newState)
        {
            if (newState == m_currentState)
            {
                return;
            }

            m_currentState = newState;
            switch (m_currentState)
            {
                case states.idle: ChangeToIdle(); break;
                case states.wander: ChangeToWander(); break;
                case states.harvest: ChangeToHarvest(); break;
                case states.craft: ChangeToCraft(); break;
                case states.GoToBase: ChangeToGoToBase(); break;
            }
        }



        private void UpdateStateMachine()
        {
            switch (m_currentState)
            {
                case states.idle: DoIdle(); break;
                case states.wander: DoWander(); break;
                case states.harvest: DoHarvest(); break;
                case states.craft: DoCraft(); break;
                case states.GoToBase: DoGoToBase(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        protected virtual void ChangeToGoToBase() { }
        
        protected virtual void ChangeToWander() { }

        protected virtual void ChangeToIdle() { }
        
        protected virtual void ChangeToHarvest() { }
        
        protected virtual void ChangeToCraft() { }
        
        protected virtual void DoWander() { }

        protected virtual void DoIdle() { }
        
        protected virtual void DoGoToBase() { }
        
        protected virtual void DoHarvest() { }
        
        protected virtual void DoCraft() { }

        
    }

    public enum states
    {
        idle,
        wander,
        harvest,
        craft,
        GoToBase
    }
