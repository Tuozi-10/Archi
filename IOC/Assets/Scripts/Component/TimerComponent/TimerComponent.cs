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
    

        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity);
            _time = ((TimerComponentData)args[0]).Time;
        }


        public async void LaunchTimer(Action callback)
        {
            if (inTimer) return;
            inTimer = true; 
            UniTask.Delay(_time);
            inTimer = false; 
            callback?.Invoke();
        }
    }
}
