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

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
           
        }
        
        private void GenerateBurger(GameObject gameObject)
        {
            Object.Instantiate(gameObject);
        }

        public void ShowBurger()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);

        }
    }
}