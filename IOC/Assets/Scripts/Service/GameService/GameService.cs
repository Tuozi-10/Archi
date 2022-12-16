using Addressables;
using Attributes;
using Service.AudioService;
using Service.SceneService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] 
        private IAudioService m_audioService;
        [DependsOnService] 
        private ISceneService m_sceneService;

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
           m_sceneService.LoadScene("New Scene");
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger); 
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UI", CreateUI); 
           //AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Cubator", );
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            Release(gameObject);
        }

        private void CreateUI(GameObject gameObject)
        {
            var UI = Object.Instantiate(gameObject);
            UI.GetComponent<UIManager>().Setup(m_sceneService);
        }
        
    }
}