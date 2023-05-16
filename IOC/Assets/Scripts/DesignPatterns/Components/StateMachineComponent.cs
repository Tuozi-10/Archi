using System;
using entities;

namespace Dp.DesignPatterns
{
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
            m_currentState = states.harvest;
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
                case states.idle:
                    ChangeToIdle();
                    break;
                case states.harvest:
                    ChangeToHarvest();
                    break;
                case states.craft:
                    ChangeToCraft();
                    break;
                case states.harvestCompleted:
                    ChangeToHarvestCompleted();
                    break;
                case states.stock:
                    ChangeToStock();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateStateMachine()
        {
            switch (m_currentState)
            {
                case states.idle:
                    DoIdle();
                    break;
                case states.harvest:
                    DoHarvest();
                    break;
                case states.craft:
                    DoCraft();
                    break;
                case states.harvestCompleted:
                    DoHarvestCompleted();
                    break;
                case states.stock:
                    DoStock();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void ChangeToHarvestCompleted() { }

        protected virtual void ChangeToIdle() { }

        protected virtual void ChangeToHarvest() { }

        protected virtual void ChangeToCraft() { }

        protected virtual void ChangeToStock() { }

        protected virtual void DoHarvestCompleted() { }

        protected virtual void DoIdle() { }

        protected virtual void DoHarvest() { }

        protected virtual void DoCraft() { }
        
        protected virtual void DoStock() { }
    }

    public enum states
    {
        idle,
        harvest,
        harvestCompleted,
        craft,
        stock
    }
}