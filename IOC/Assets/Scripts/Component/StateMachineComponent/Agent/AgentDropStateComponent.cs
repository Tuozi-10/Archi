using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentDropStateComponent : StateComponent
    {
        private TimerComponent _timerComponent;
        private DropRessourceComponent _dropRessourceComponent;



        public void Init(Entity entity, StateMachineComponent stateMachineComponent, TimerComponent timerComponent, DropRessourceComponent dropRessourceComponent)
        {
            Init(entity, stateMachineComponent);
            _timerComponent = timerComponent;
            _dropRessourceComponent = dropRessourceComponent;
        }
        
        protected override void Enable()
        { 
            base.Enable();
            _dropRessourceComponent.Drop();
            _timerComponent.LaunchTimer();
        }

      

        public void EndDrop()
        {
            _stateMachine.ChangeState((int)AgentStateEnum.GoToRessource);
        }
    }
}