using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentGoToRessourceStateComponent : StateComponent
    {
        private MoveToTargetComponent _moveToTargetComponent;
        private CompareDistanceComponent _compareDistanceComponent;


        /// <param name="args"> stateMachine, moveToTargetComponent, compareDistanceComponent</param>
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity, args);
            _moveToTargetComponent = (MoveToTargetComponent)args[1];
            _compareDistanceComponent = (CompareDistanceComponent)args[2];
        }

        protected override void Enable()
        {
            base.Enable();
            _moveToTargetComponent.MoveToTarget();
        }

        protected override void Update()
        {
            if (_compareDistanceComponent.CheckDistance())
            {
                _stateMachine.ChangeState((int)AgentStateEnum.Harvest);
            }
        }
    }
}