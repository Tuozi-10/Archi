using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace
{
    public class TickableSwitachable : AlaidService, ITickable
    {

        [ServiceInit]
        protected virtual void Init()
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
}