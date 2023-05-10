using System;
using UnityEngine;

namespace _2
{
     public abstract class StateMachineComponent : IComponent
    {
        private States m_currentState = States.idle;  
        public readonly Entity m_entity;

        public StateMachineComponent(Entity owner)
        {
            m_entity = owner;
        }
        
        public virtual void Init()
        {
            m_currentState = States.wander;
        }
        
        public void Update()
        {
            UpdateStateMachine();
        }

        public void ChangeState(States newState)
        {
            if (newState == m_currentState)
            {
                return;
            }

            m_currentState = newState;
            switch (m_currentState)
            {
                case States.idle: ChangeToIdle(); break;
                case States.wander: ChangeToWander(); break;
                case States.harvest: ChangeToHarvest(); break;
                case States.craft: ChangeToCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateStateMachine()
        {
            switch (m_currentState)
            {
                case States.idle: DoIdle(); break;
                case States.wander: DoWander(); break;
                case States.harvest: DoHarvest(); break;
                case States.craft: DoCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        protected virtual void ChangeToWander() { }

        protected virtual void ChangeToIdle() { }
        
        protected virtual void ChangeToHarvest() { }
        
        protected virtual void ChangeToCraft() { }
        
        protected virtual void DoWander() { }

        protected virtual void DoIdle() { }
        
        protected virtual void DoHarvest() { }
        
        protected virtual void DoCraft() { }

        
    }
}