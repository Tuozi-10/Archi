using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentDropStateComponent : StateComponent
    {
        private TimerComponent timerComponent;
        private DropRessourceComponent dropRessourceComponent;


        /// <param name="args">timerComponent, dropRessourceComponent</param>
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            timerComponent =(TimerComponent) args[1];
            dropRessourceComponent = (DropRessourceComponent)args[2];
        }
        
        protected override void Enable()
        {
            base.Enable();
            dropRessourceComponent.Drop();
            timerComponent.LaunchTimer();
        }

        public void EndHarvest()
        {
            _stateMachine.ChangeState((int)AgentStateEnum.GoToDrop);
        }
    }
}