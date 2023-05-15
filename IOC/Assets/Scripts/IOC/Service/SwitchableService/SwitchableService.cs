using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableService : ISwitchableService
{
    protected bool Switchable = false;
    
    public virtual void Switch()
    {
        Switchable = !Switchable;
    }

    public virtual void Enable()
    {
        Switchable = true;
    }
    
    public virtual void Disable()
    {
        Switchable = false;
    }

    public virtual void OnTick(float deltaTime)
    {
        
    }
}
