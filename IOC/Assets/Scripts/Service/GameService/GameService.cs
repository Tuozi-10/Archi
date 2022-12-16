using Addressables;
using Attributes;
using Service.AudioService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] 
        private IAudioService m_audioService;

        private GameObject obj = null;

        [ServiceInit]
        private void Initialize()
        {
            //m_audioService.PlaySound(0);
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
        }
        
        private void GenerateBurger(GameObject gameObject)
        {
            obj = gameObject;
        }

        public void ShowBurger()
        {
            var burger = Object.Instantiate(obj);
            Release(obj);
        }
    }
}