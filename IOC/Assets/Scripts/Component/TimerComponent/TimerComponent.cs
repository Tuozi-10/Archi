using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Components
{
    public class TimerComponent : Component
    {
        private int _time;
        private Action _callback;
        private bool inTimer;
    

        
        public  void Init(Entity entity, TimerComponentData data, Action callback)
        {
            base.Init(entity);
            _time = (data).Time;
            _callback = callback;
        }


        public async void LaunchTimer()
        {
            if (inTimer) return;
            inTimer = true; 
           await UniTask.Delay(_time);
            inTimer = false; 
            _callback?.Invoke();
        }
    }
}
