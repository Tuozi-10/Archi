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
            m_sceneService.LoadScene("FirstScene");
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeCanvas", GenerateCanvas);
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            Release(gameObject);
        }
        
        private void GenerateCanvas(GameObject gameObject)
        {
            var canvas = Object.Instantiate(gameObject);
            canvas.GetComponent<ChangeScene>().Setup(m_sceneService);
            Release(gameObject);
        }
    }
}