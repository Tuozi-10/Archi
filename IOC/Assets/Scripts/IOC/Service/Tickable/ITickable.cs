using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Service;
using UnityEngine;

public interface ITickable : IService
{
     protected async void MyUpdate()
     {
          while (true)
          {
               await UniTask.DelayFrame(0);
               OnTick(Time.deltaTime);
          }
     }
     
     
     void OnTick(float deltaTime);
}
