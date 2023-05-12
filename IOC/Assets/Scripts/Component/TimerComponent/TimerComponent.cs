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
    


        /// <param name="args"> time, callback</param>
        public override void Init(Entity entity, params object[] args)
        {
            base.Init(entity);
            _time = ((TimerComponentData)args[0]).Time;
            _callback = (Action)args[1];
        }


        public async void LaunchTimer()
        {
            if (inTimer) return;
            inTimer = true; 
            UniTask.Delay(_time);
            inTimer = false; 
            _callback?.Invoke();
        }
    }
}
