using Dp;
using Attributes;
//using Cysharp.Threading.Tasks;
using DesignPatterns;
using Service.AudioService;
using UnityEngine;
//using static UnityEngine.AddressableAssets.Addressables;

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
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            //Release(gameObject);
        }


    }
}