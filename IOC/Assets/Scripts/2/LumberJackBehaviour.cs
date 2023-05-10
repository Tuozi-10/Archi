using System.Collections;
using System.Collections.Generic;
using _2;
using Unity.VisualScripting;
using UnityEngine;

public class LumberjackBehaviour : StateMachineComponent
{
        
    public LumberjackBehaviour(Entity owner) : base(owner)
    {
    }
        
    public override void Init()
    {
        ChangeState(States.harvest);
    }

    protected override void DoHarvest()
    {
        base.DoHarvest();
        if (m_entity) // is full, for example, todo true logic
        {
            // todo go deposit
        }
    }
}