using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlaidService : ISwitchableService
{
    public bool Active { get; set; }

    public void Toggle(bool active)
    {
        active = !active;
    }

    public virtual void Enable()
    {
        Active = true;
    }

    public virtual void Disable()
    {
        Active = false;
    }
}
