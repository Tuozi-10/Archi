using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchableService
{
    bool Active { get; set; }
    void Toggle(bool active);
    void Enable();
    void Disable();
}
