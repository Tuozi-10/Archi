using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HubStructure : Structure
{
    private List<ResourceContainer> containers = new List<ResourceContainer>();
    
    public void AssignContainers(params ResourceContainer[] c)
    {
        foreach (var container in c)
        {
            AddComponent(container);
            containers.Add(container);
        }
    }
    
    protected override void Work()
    {
        var unitContainer = WorkingUnit.Container;
        
        if(unitContainer.associatedResource < 0 || unitContainer.associatedResource >= containers.Count) return;

        var container = containers[unitContainer.associatedResource];

        unitContainer.Transfer(container);
    }

    public override bool CanWork()
    {
        return true;
    }
}
