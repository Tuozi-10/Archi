using Dp.DesignPatterns;
using entities;
using UnityEngine;

public class HarvesterBehaviour : StateMachineComponent
{
    private MoveToTargetComponent _moveToTargetComponent;
    private ResourceFinderComponent _resourceFinderComponent;

    public HarvesterBehaviour(Entity owner) : base(owner)
    {
        _moveToTargetComponent = owner.GetCompositeComponent<MoveToTargetComponent>();
        _resourceFinderComponent = owner.GetCompositeComponent<ResourceFinderComponent>();
    }

    public override void Init()
    {
        ChangeState(states.harvest);
    }

    protected override void ChangeToHarvestCompleted()
    {
        Debug.Log("Completed! Must go back to Hub!");
        _moveToTargetComponent.SetTarget(SceneReferenceHolder.instance.hub);
    }

    protected override void ChangeToIdle() { }

    protected override void ChangeToHarvest()
    {
        Debug.Log("Start harvesting!");
        _moveToTargetComponent.SetTarget(SceneReferenceHolder.instance.wood);
    }

    protected override void ChangeToCraft()
    {
        Debug.Log("Finished collecting resources. Must craft if possible!");
        _moveToTargetComponent.SetTarget(SceneReferenceHolder.instance.forge);
    }

    protected override void ChangeToStock()
    {
        Debug.Log("Crafted a tool that is not stocked yet. Must go to stock!");
        _moveToTargetComponent.SetTarget(SceneReferenceHolder.instance.stock);
    }

    protected override void DoHarvestCompleted()
    {
        Debug.Log("Going back to hub...");

        if (_moveToTargetComponent.MoveToPoint())
        {
            SceneReferenceHolder.instance.hubWood += m_entity.stone;
            m_entity.stone = 0;
            ChangeState(states.craft);
        }
    }

    protected override void DoIdle() { }

    protected override void DoHarvest()
    {
        if (_moveToTargetComponent.MoveToPoint())
        {
            if (_resourceFinderComponent.LoadingResource()) ChangeState(states.harvestCompleted);
        }
    }

    protected override void DoCraft()
    {
        if (_moveToTargetComponent.MoveToPoint())
        {
            Debug.Log("Going to forge");
            // Par exemple : 2 bois pour faire un tool
            SceneReferenceHolder.instance.hubStone -= 2;

            ChangeState(states.stock);
        }
    }

    protected override void DoStock()
    {
        if (_moveToTargetComponent.MoveToPoint())
        {
            Debug.Log("Going to stock...");
            SceneReferenceHolder.instance.hubTools += 2;
            
            if(SceneReferenceHolder.instance.hubStone >= 2) ChangeState(states.craft);
            else ChangeState(states.harvest);
        }
    }
}