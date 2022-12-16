using Addressables;
using Attributes;
using Service.AudioService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : SwitchableService, IGameService
    {
        [DependsOnService] 
        private IAudioService m_audioService;
        [DependsOnService]
        private ISceneService m_sceneService;
        [DependsOnService]
        private IFightService m_fightService;

        private bool isEnabled;
        
        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
            m_sceneService.LoadScene("FirstScene");
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
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
            canvas.GetComponent<ChangeScene>().Setup(m_sceneService, m_fightService);
            Release(gameObject);
        }

        void Switch()
        {
            
        }

        void Enable()
        {
            base.Enable();
        }

        void Disable()
        {
            base.Disable();
        }
    }
}