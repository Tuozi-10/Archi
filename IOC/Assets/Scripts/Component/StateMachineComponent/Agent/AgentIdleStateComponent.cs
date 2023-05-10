using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentIdleStateComponent : StateComponent
    {
        private RessourceComponent _ressourceComponent;

        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            _ressourceComponent = (RessourceComponent)args[1];
        }

        protected override void Enable()
        {
            base.Enable();
            if (_ressourceComponent.Ressource > 0)
                _stateMachine.ChangeState((int)AgentStateEnum.GoToDrop);
        }
    }
}