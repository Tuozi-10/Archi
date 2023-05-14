using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentIdleStateComponent : StateComponent
    {
        private RessourceComponent _ressourceComponent;

        public  void Init(Entity entity, StateMachineComponent stateMachineComponent, RessourceComponent ressourceComponent)
        {
            Init(entity, stateMachineComponent);
            _ressourceComponent = ressourceComponent;
        }

        protected override void Enable()
        {
            base.Enable();
            if (_ressourceComponent.Ressource > 0)
                _stateMachine.ChangeState((int)AgentStateEnum.GoToRessource);
        }
    }
}