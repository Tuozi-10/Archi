using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeWorker : GatherWorker
{
    private ResourceContainer woodContainer;
    private ResourceContainer rockContainer;
    
    public ForgeWorker(Unit owner, ScriptableUnitData unitData, ResourceContainer container,ResourceContainer wContainer,ResourceContainer rContainer) : base(owner, unitData, container)
    {
        woodContainer = wContainer;
        rockContainer = rContainer;
    }
    
    public override void Init()
    {
        m_currentState = states.idle;
        ChangeToIdle();
    }

    protected override void ChangeToIdle()
    {
        EventManager.AddListener<OnStockCraftableEvent>(CollectHubResources);
    }

    private void CollectHubResources(OnStockCraftableEvent _)
    {
        EventManager.RemoveListener<OnStockCraftableEvent>(CollectHubResources);
        targetIndex = data.TargetStructures.Length - 1;
        ChangeState(states.wander);
    }

    protected override void OnDestinationArrived()
    {
        ChangeState(states.work);
    }

    protected override void NextWork()
    {
        // TODO
        targetIndex++;
        if (targetIndex >= data.TargetStructures.Length-1) targetIndex = 0;
        
        
        if (!targetStructure.CanWork())
        {
            ChangeState(states.idle);
            return;
        }
        
        ChangeState(states.work);
    }
}   
