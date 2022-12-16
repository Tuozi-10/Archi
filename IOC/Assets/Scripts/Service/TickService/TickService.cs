using System;
using System.Collections.Generic;
using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Service.TickService
{
    public class TickService: ITickService
    {
        private bool enable = true;

        [ServiceInit]
        void Initialize()
        {
            Update();
        }
        
        public async void Update()
        {
            while (enable)
            {
                await UniTask.DelayFrame(0);
                OnUpdate?.Invoke();
            }
        }

        public event Action OnUpdate;

        public void SetServiceState(bool state)
        {
            enable = state;
            if(enable)Update();
        }

        public void SwitchServiceState()
        {
            SetServiceState(!enable);
        }
    }
}