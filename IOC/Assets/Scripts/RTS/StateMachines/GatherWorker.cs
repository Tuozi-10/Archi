using Service;
using UnityEngine;

public class GatherWorker : UnitStateMachine
{
    private Structure targetStructure => RTSService.GetStructure(data.TargetResources[targetIndex]);
    private int targetIndex;

    private int currentResource = 0;
    private float workTimer = 0;
    private ResourceContainer container;
    
    public GatherWorker(Unit owner, ScriptableUnitData unitData,ResourceContainer container) : base(owner, unitData)
    {
        Agent.speed = data.MoveSpeed;
        this.container = container;
    }
    
    protected override void DoWander()
    {
        Agent.SetDestination(targetStructure.EntrancePosition);

        var distance = Vector3.Distance(targetStructure.Position, Position);
        
        if (!(Vector3.Distance(targetStructure.Position, Position) <= data.WorkRange)) return;
        
        Agent.velocity = Vector3.zero;
        Agent.SetDestination(Position);
        ChangeState(states.work);
    }
    
    protected override void ChangeToWork()
    {
        workTimer = 0;
        targetStructure.StartWork(unit);
    }

    protected override void DoWork()
    {
        workTimer += Time.deltaTime;
        
        if(workTimer < data.WorkTime) return;
        
        workTimer = 0;
        targetStructure.EndWork();
        
        targetIndex++;
        if (targetIndex >= data.TargetResources.Length) targetIndex = 0;
        
        ChangeState(states.wander);
    }
}
