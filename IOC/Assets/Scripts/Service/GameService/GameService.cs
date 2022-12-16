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
        [DependsOnService]
        private ISceneService m_sceneService;

        [ServiceInit]
        private void Initialize()
        {
           m_audioService.PlaySound(0);
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UI", GenerateUI);
           m_sceneService.LoadScene("UI");
           
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
        }
        
        private void GenerateUI(GameObject gameObject)
        {
            var ui = Object.Instantiate(gameObject);
            ui.GetComponent<UIManager>().Setup(m_sceneService);
        }
        
    }
}