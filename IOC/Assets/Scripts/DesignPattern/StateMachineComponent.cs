using System;
using DefaultNamespace;

namespace DesignPattern
{
    public abstract class StateMachineComponent : IComponent
    {
        private States _currentState = States.IDLE;  
        public readonly Entity _entity;

        public StateMachineComponent(Entity owner)
        {
            _entity = owner;
        }
        
        public virtual void Init()
        {
            _currentState = States.WANDER;
        }
        
        public void Update()
        {
            UpdateStateMachine();
        }

        public void ChangeState(States newState)
        {
            if (newState == _currentState)
            {
                return;
            }

            _currentState = newState;
            switch (_currentState)
            {
                case States.IDLE: ChangeToIdle(); break;
                case States.WANDER: ChangeToWander(); break;
                case States.HARVEST: ChangeToHarvest(); break;
                case States.DEPOSIT: ChangeToDeposit(); break;
                case States.CRAFT: ChangeToCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateStateMachine()
        {
            switch (_currentState)
            {
                case States.IDLE: DoIdle(); break;
                case States.WANDER: DoWander(); break;
                case States.HARVEST: DoHarvest(); break;
                case States.DEPOSIT: DoDeposit(); break;
                case States.CRAFT: DoCraft(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        protected virtual void ChangeToWander() { }

        protected virtual void ChangeToIdle() { }
        
        protected virtual void ChangeToHarvest() { }
        
        protected virtual void ChangeToDeposit() { }
        
        protected virtual void ChangeToCraft() { }
        
        protected virtual void DoWander() { }

        protected virtual void DoIdle() { }
        
        protected virtual void DoHarvest() { }
        
        protected virtual void DoDeposit() { }
        
        protected virtual void DoCraft() { }
    }

    public enum States
    {
        IDLE,
        WANDER,
        HARVEST,
        DEPOSIT,
        CRAFT
    }
}