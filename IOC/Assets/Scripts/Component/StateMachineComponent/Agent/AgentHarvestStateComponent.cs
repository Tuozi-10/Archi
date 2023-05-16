using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentHarvestStateComponent :StateComponent
    {
        private TimerComponent _timerComponent;
        private SteelRessourceComponent _steelRessourceComponent;
        
        public void Init(Entity entity,StateMachineComponent stateMachineComponent, TimerComponent timerComponent, SteelRessourceComponent steelRessourceComponent)
        {
            Init(entity, stateMachineComponent);
            _timerComponent = timerComponent;
            _steelRessourceComponent = steelRessourceComponent;
        }
        
        protected override void Enable()
        {
            base.Enable();
            _steelRessourceComponent.SteelRessource();
            _timerComponent.LaunchTimer();
        }

        public void EndHarvest()
        {
            _stateMachine.ChangeState((int)AgentStateEnum.GoToDrop);
        }
        
    }
}
