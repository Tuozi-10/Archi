using Addressables;
using Attributes;
using Service.AudioService;
using Service.SceneService;
using Unity.VisualScripting;
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
            
            menu.AssignToggleMethod(SwitchSceneService);

            void SwitchSceneService(bool value)
            {
                if (value)
                {
                    m_sceneService.Enable();
                }
                else
                {
                    m_sceneService.Disable();
                }
            }
            
            menu.AssignButtonMethod(()=>m_sceneService.LoadScene(0));
            
            Release(menuObj);
        }

    }
}