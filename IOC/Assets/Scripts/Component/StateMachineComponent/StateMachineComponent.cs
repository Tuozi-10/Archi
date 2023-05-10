using System;


namespace Components
{
    public  class StateMachineComponent : Component
    {
        public int CurrentState;
        private StateComponent[] _allStates;
        private int startState;

        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            _allStates = (StateComponent[])args[0];
            for (int i = 0; i < _allStates.Length; i++)
            {
                _allStates[i].Enabled = false;
            }
            startState = ((StateMachineComponentData)args[1]).StartState;
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

   