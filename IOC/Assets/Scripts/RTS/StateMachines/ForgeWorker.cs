using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeWorker : GatherWorker
{
    public ForgeWorker(Unit owner, ScriptableUnitData unitData, ResourceContainer container) : base(owner, unitData, container)
    {
        
    }
    
    protected override void OnDestinationArrived()
    {
        ChangeState(states.work);
    }

    protected override void NextWork()
    {
        
    }
}
