using _2;
using UnityEngine;

public class LumberjackBehaviour : StateMachineComponent
{
    private GameObject hub;
    private GameObject treeParent;
        
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