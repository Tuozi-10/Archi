using Addressables;
using Attributes;
using Service.AudioService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] private IAudioService m_audioService;

        [DependsOnService] private ISceneService sceneService;

        [DependsOnService] private IUICanvasSwitchableService uiCanvasService;

        [DependsOnService] private IFightService fightService;

        public GameObject burger;

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            sceneService.LoadScene("UIScene");
            uiCanvasService.LinkButton();
        }

        private void GenerateBurger(GameObject gameObject)
        {
            burger = Object.Instantiate(gameObject);
            fightService.fighter = burger;
            Release(gameObject);
            
        }
    }
}