using System;
using Service;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateMachine : IComponent
{
    private states m_currentState = states.idle;
    protected readonly Unit unit;
    protected NavMeshAgent Agent => unit.Agent;
    protected Renderer Renderer => unit.Renderer;
    protected Vector3 Position => unit.Position;
    protected readonly ScriptableUnitData data;

    public UnitStateMachine(Unit owner, ScriptableUnitData unitData)
    {
        unit = owner;
        data = unitData;

        SetMaterial(data.Material);
    }

    public void SetMaterial(Material mat)
    {
        Renderer.material = mat;
    }

    public virtual void Init()
    {
        m_currentState = states.wander;
    }

    public void Update()
    {
        UpdateStateMachine();
    }

    public void ChangeState(states newState)
    {
        if (newState == m_currentState)
        {
            return;
        }

        m_currentState = newState;
        switch (m_currentState)
        {
            case states.idle:
                ChangeToIdle();
                break;
            case states.wander:
                ChangeToWander();
                break;
            case states.work:
                ChangeToWork();
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private void UpdateStateMachine()
    {
        switch (m_currentState)
        {
            case states.idle:
                DoIdle();
                break;
            case states.wander:
                DoWander();
                break;
            case states.work:
                DoWork();
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    protected virtual void ChangeToWander()
    {
    }

    protected virtual void ChangeToIdle()
    {
    }

    protected virtual void ChangeToWork()
    {
    }

    protected virtual void DoWander()
    {
    }

    protected virtual void DoIdle()
    {
    }

    protected virtual void DoWork()
    {
    }
    
}

public enum states
{
    idle,
    wander,
    work
}