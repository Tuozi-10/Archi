using System.Collections;
using System.Collections.Generic;
using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TickableService : ITickable
{
    
    [ServiceInit]
    private void Init()
    {
        Update();
    }
    private async void Update()
    {
        while (true)
        {
            await UniTask.DelayFrame(0);
            OnUpdate();
        }
    }

    public virtual void OnUpdate()
    {
        
    }

}
