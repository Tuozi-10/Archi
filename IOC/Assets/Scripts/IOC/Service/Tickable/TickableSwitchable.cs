using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickableSwitchable : ITickableSwitchable
{
    
    
    public virtual void OnTick(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Switch()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Enable()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Disable()
    {
        throw new System.NotImplementedException();
    }
}
