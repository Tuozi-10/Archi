using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableService : ISwitchableService
{
    bool Switchable = false;
    
    public void Switch()
    {
        Switchable = !Switchable;
    }

    public void Enable()
    {
        
    }

    public void Disable()
    {
        
    }
}
