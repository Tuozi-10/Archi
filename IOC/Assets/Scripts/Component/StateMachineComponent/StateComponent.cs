using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
public class StateComponent : Component
{
    protected StateMachineComponent _stateMachine;
     protected void Init(Entity entity, StateMachineComponent stateMachine)
    {
       Init(entity, false);
       _stateMachine = stateMachine;
    }
     
     
} 
}
