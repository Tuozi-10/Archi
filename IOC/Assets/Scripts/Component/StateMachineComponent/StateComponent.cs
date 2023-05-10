using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
public class StateComponent : Component
{
    protected StateMachineComponent _stateMachine;
    public override void Init(Entity entity, params object[] args)
    {
        base.Init(entity, args);
        _stateMachine = (StateMachineComponent)args[0];
    }
} 
}
