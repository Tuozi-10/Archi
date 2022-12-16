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
        
        [DependsOnService] 
        private IFightService m_fightService;

        //[ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Menu", LoadMenu);
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            m_fightService.SetFighter(burger);
            Release(gameObject);
        }

        private void LoadMenu(GameObject menuObj)
        {
            var menu = Object.Instantiate(menuObj).GetComponent<MenuAssigner>();
            
            menu.AssignToggleButtonMethod(SwitchSceneService,true);

            void SwitchSceneService()
            {
                m_fightService.Toggle();
            }
            
            menu.AssignSceneButtonMethod(()=>m_fightService.Toggle());
            
            Release(menuObj);
        }
    }
}