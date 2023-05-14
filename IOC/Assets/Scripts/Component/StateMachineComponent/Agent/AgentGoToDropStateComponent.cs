using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class AgentGoToDropStateComponent : StateComponent
    {
        private MoveToTargetComponent _moveToTargetComponent;
        private CompareDistanceComponent _compareDistanceComponent;

        public  void Init(Entity entity, StateMachineComponent stateMachineComponent, MoveToTargetComponent moveToTargetComponent, CompareDistanceComponent compareDistanceComponent)
        {
            Init(entity, stateMachineComponent);
            _moveToTargetComponent = moveToTargetComponent;
            _compareDistanceComponent = compareDistanceComponent;
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
                _stateMachine.ChangeState((int)AgentStateEnum.Drop);
            }
        }
    }
}
