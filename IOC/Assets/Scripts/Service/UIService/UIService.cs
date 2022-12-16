using Addressables;
using Attributes;
using Service.SceneService;
using UnityEngine;

namespace Service.UIService
{
    public class UIService : IUIService
    {
        [DependsOnService] 
        private IGameService m_gameService;
        [DependsOnService]
        private ISceneService m_sceneService;
        
        
        
        [ServiceInit]
        private void Initialize()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UI", CreateUI); 
        }

        private void CreateUI(GameObject gameObject)
        {
            var UI = Object.Instantiate(gameObject);
            UI.GetComponent<UIManager>().Setup(m_sceneService, this, m_gameService);
        }
    }
}