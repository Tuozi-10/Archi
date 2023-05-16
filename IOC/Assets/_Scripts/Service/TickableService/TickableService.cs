using Attributes;
using Cysharp.Threading.Tasks;

namespace Service
{
    public class TickableService : ITickableService
    {
        public double tickRate { get; protected set; }

        [ServiceInit]
        protected virtual void Initialize()
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
