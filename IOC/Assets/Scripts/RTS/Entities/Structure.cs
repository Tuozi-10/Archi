using System;
using UnityEngine;

public abstract class Structure : Entity
{
    [SerializeField] private Transform entranceOffset;
    public Vector3 EntrancePosition => entranceOffset.position;

    [field: SerializeField] public int AssociatedResource { get; private set; }
    public bool Working => WorkingUnit != null;
    public Unit WorkingUnit { get; private set; }
    public event Action<Unit> OnWorkEnded;

    protected abstract void Work();

    public void StartWork(Unit unit)
    {
        WorkingUnit = unit;
    }

    public void EndWork()
    {
        Work();
        
        OnWorkEnded?.Invoke(WorkingUnit);
        WorkingUnit = null;
    }
}
