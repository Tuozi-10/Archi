using System;
using UnityEngine;


namespace Components
{
    public  class StateMachineComponent : Component
    {
        public int CurrentState;
        private StateComponent[] _allStates;
        private int startState;

        public  void Init(Entity entity, StateComponent[] allStates, StateMachineComponentData data)
        {
            base.Init(entity);
            _allStates = allStates;
            for (int i = 0; i < _allStates.Length; i++)
            {
                _allStates[i].Enabled = false;
            }
            startState = (data).StartState;
            _allStates[this.startState].Enabled = true;
        }
        public void ChangeState(int newState)
        {
            _allStates[CurrentState].Enabled = false;
            CurrentState = newState;
            _allStates[newState].Enabled = true;
      
        }

  
    }
}

   