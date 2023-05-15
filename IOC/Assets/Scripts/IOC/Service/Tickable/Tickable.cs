using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Tickable : ITickable
{
    [ServiceInit]
    void Initialize()
    {
        MyUpdate();
    }
    
    protected async void MyUpdate()
    {
        while (true)
        {
            await UniTask.DelayFrame(0);
            OnTick(Time.deltaTime);
        }
    }

    public virtual void OnTick(float deltaTime)
    {
        
    }
}