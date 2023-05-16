using System;
using UnityEngine;

public abstract class Structure : Entity
{
    [SerializeField] private Transform entranceOffset;
    public Vector3 EntrancePosition => entranceOffset.position;
    public bool Working => WorkingUnit != null;
    public Unit WorkingUnit { get; private set; }
    public event Action<Unit> OnWorkEnded;

    protected abstract void Work();

    public void StartWork(Unit unit)
    {
        WorkingUnit = unit;
    }

    public abstract bool CanWork();

    public void EndWork()
    {
        Work();
        
        OnWorkEnded?.Invoke(WorkingUnit);
        WorkingUnit = null;
    }
}
