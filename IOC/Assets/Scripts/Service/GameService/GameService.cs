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
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Menu", LoadMenu);
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            Release(gameObject);
        }

        private void LoadMenu(GameObject menuObj)
        {
            var menu = Object.Instantiate(menuObj).GetComponent<MenuAssigner>();
            
            menu.AssignButtonMethod(()=>m_sceneService.LoadScene(0));
            
            Release(menuObj);
        }

    }
}