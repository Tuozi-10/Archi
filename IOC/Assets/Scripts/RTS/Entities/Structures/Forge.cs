using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : Structure
{
    [SerializeField] private HubStructure hub;
    
    protected override void Work()
    {
        
    }

    public override bool CanWork()
    {
        return false;
    }
}
