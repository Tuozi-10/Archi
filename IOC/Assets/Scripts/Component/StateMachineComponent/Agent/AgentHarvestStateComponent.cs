using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentHarvestStateComponent :StateComponent
    {
        private TimerComponent timerComponent;
        private SteelRessourceComponent steelRessourceComponent;
        
        
        /// <param name="args"> stateMachine, timerComponent, steelRessourceComponent</param>
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            timerComponent =(TimerComponent) args[1];
            steelRessourceComponent = (SteelRessourceComponent)args[2];
        }
        
        protected override void Enable()
        {
            base.Enable();
            steelRessourceComponent.SteelRessource();
            timerComponent.LaunchTimer();
        }

        public void EndHarvest()
        {
            _stateMachine.ChangeState((int)AgentStateEnum.GoToDrop);
        }
        
    }
}
