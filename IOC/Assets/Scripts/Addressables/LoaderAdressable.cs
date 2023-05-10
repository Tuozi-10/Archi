using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Addressables
{
    
public class LoaderAdressable 
{
    public LoaderAdressable(int amountLoad)
    {
        AmountLoad = amountLoad;
    }

    public readonly int AmountLoad;
    public int CurrentLoad;
    public Action TempEnabledCallback;

    public void CheckAmountLoad()
    {
        CurrentLoad++;
        if (CurrentLoad != AmountLoad) return;
        TempEnabledCallback?.Invoke();
        TempEnabledCallback = null;
    }
}
}
