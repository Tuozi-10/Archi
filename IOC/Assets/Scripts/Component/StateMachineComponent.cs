using System;
using UnityEngine;

namespace Component
{
    public abstract class StateMachineComponent : IComponent
    {
        private States m_currentState = States.Idle;
        public readonly Entity m_entity;

        public StateMachineComponent(Entity owner)
        {
            m_entity = owner;
        }
        
        public virtual void Init()
        {
            m_currentState = States.Idle;
        }

        public void Update()
        {
            UpdateStateMachine();
        }


        public void ChangeState(States newState)
        {
            if(newState == m_currentState) return;
            
            m_currentState = newState;

            switch (m_currentState)
            {
                case States.Idle: ChangeToIdle(); break;
                case States.Wander: ChangeToWander(); break;
                case States.Harvest: ChangeToHarvest(); break;
                case States.Craft: ChangeToCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        private void UpdateStateMachine()
        {
            switch (m_currentState)
            {
                case States.Idle: DoIdle(); break;
                case States.Wander: DoWander(); break;
                case States.Harvest: DoHarvest(); break;
                case States.Craft: DoCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void ChangeToCraft() { }
        protected virtual void DoCraft(){}
        protected virtual void ChangeToHarvest() { }
        protected virtual void DoHarvest(){}
        protected virtual void ChangeToWander() { }
        protected virtual void DoWander(){}
        protected virtual void ChangeToIdle() { }
        protected virtual void DoIdle(){}
    }

    public enum States
    {
        Idle,
        Wander,
        Harvest,
        Craft
    }
}