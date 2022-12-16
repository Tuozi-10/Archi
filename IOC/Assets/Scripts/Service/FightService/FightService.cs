using Addressables;
using Attributes;
using UnityEngine;

namespace Service
{
    public class FightService : TickableSwitchableService, IFightService
    {
        private GameObject _burger;
        
        [ServiceInit]
        protected override void Initialize()
        {
            base.Initialize();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            Enable();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (_burger is not null)
            {
                _burger.transform.Rotate(Vector3.up, 1f);
            }
        } 
        
        public override void Toggle()
        {
            base.Toggle();
            if (_burger is not null)
            {
                if (isActive) Enable();
                else Disable();
            }
        }

        public override void Enable()
        {
            base.Enable();
            if (_burger is not null) _burger.gameObject.SetActive(true);
        }

        public override void Disable()
        {
            base.Disable();
            if (_burger is not null) _burger.gameObject.SetActive(false);
        }
        
        private void GenerateBurger(GameObject burger)
        {
            _burger = Object.Instantiate(burger);
            _burger.SetActive(isActive);
        }
    }
}
