using Service;
using UnityEngine;

public class GatherWorker : UnitStateMachine
{
    protected Structure targetStructure => RTSService.GetStructure(data.TargetStructures[targetIndex]);
    protected int targetIndex;
    
    private float workTimer = 0;
    protected ResourceContainer container;
    
    public GatherWorker(Unit owner, ScriptableUnitData unitData,ResourceContainer container) : base(owner, unitData)
    {
        Agent.speed = data.MoveSpeed;
        this.container = container;
    }
    
    protected override void DoWander()
    {
        Agent.SetDestination(targetStructure.EntrancePosition);
        
        if (!(Vector3.Distance(targetStructure.Position, Position) <= data.WorkRange)) return;
        
        Agent.velocity = Vector3.zero;
        Agent.SetDestination(Position);
        OnDestinationArrived();
    }

    protected virtual void OnDestinationArrived()
    {
        ChangeState(states.work);
    }
    
    protected override void ChangeToWork()
    {
        workTimer = 0;
        targetStructure.StartWork(unit);
    }

    protected override void DoWork()
    {
        if (!targetStructure.CanWork())
        {
            NextWork();
            return;
        }
        
        workTimer += Time.deltaTime;
        
        if(workTimer < data.WorkTime) return;
        
        workTimer = 0;
        targetStructure.EndWork();
        
        NextWork();
    }

    protected virtual void NextWork()
    {
        targetIndex++;
        if (targetIndex >= data.TargetStructures.Length) targetIndex = 0;
        
        ChangeState(states.wander);
        
    }
}
