using Addressables;
using Attributes;
using Service.AudioService;
using Service.SceneService;
using Service.UIService;
using UI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] private IAudioService m_audioService;
        [DependsOnService] private ISceneService m_sceneService;
        [DependsOnService] private IUIService m_uiService;

        [ServiceInit]
        private void Initialize()
        {
            InitializeInGameScene();
        }


        public void InitializeInGameScene()
        {
            m_uiService.DisplayMainMenu();
            m_uiService.DisplayPopUp();
        }
    }
}