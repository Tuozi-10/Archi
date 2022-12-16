using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchableService
{
    void Toggle(bool active);
    void Enable();
    void Disable();
}
