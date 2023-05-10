using _2;
using UnityEngine;
using UnityEngine.AI;

public class DiggerBehaviour : StateMachineComponent
{
    private GameObject hub;
    private GameObject stoneParent;
    
    public DiggerBehaviour(Entity owner) : base(owner)
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
            m_entity.GetComponent<NavMeshAgent>().SetDestination(hub.transform.position);
        }
    }
}
