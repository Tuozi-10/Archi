using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Service.AudioService;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : TickableSwitchable, IGameService
    {
        [DependsOnService] private IAudioService m_audioService;
        [DependsOnService] private IUIService m_UIService;

        private GameObject obj = null;
        private GameObject burger = null;


        [ServiceInit]
        private void Initialize()
        {
            //m_audioService.PlaySound(0);
            //AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            m_UIService.ShowUIMainMenu();
            //MyUpdate();
        }
        protected async void MyUpdate()
        {
            while (true)
            {
                await UniTask.DelayFrame(0);
                OnTick(Time.deltaTime);
            }
        }
        

        private void GenerateBurger(GameObject gameObject)
        {
            obj = gameObject;
            burger = Object.Instantiate(obj);
            burger.SetActive(false);
            log.Log("Burger Generated");
        }

        public void ShowBurger()
        {
            if (!burger) return;
            burger = Object.Instantiate(obj);
            Release(obj);
        }

        public override void Switch()
        {
  Enable();

            //Switchable = !Switchable;
        }

        public override void Enable()
        {
            if (!burger) return;
            burger.SetActive(true);
        }

        public override void Disable()
        {
            if (!burger) return;
            burger.SetActive(false);
        }

        public override void OnTick(float deltaTime)
        {
            if (!burger) return;
            burger.transform.rotation = Quaternion.Euler(0, 0, burger.transform.rotation.eulerAngles.z + 1);
        }
        
    }
}