using System;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using Service.AudioService;
using Service.SceneService;
using Service.TickService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;

namespace Service
{
    public class GameService : IGameService
    {
        
        
        [DependsOnService] 
        private IAudioService m_audioService;
        [DependsOnService] 
        private ISceneService m_sceneService;
        [DependsOnService] 
        private ITickService m_tickService;

        private List<GameObject> gameObjectDependency = new List<GameObject>();
        private bool currentServiceState = true;

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
           m_sceneService.LoadScene("New Scene");
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
        }

        

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            var burgerMod = burger.GetComponent<BurgerModifier>();
            burgerMod.Setup(this, m_tickService);
            gameObjectDependency.Add(burger);
            Release(gameObject);
        }

        

        public void SetServiceState(bool state)
        {
            currentServiceState = state;
            for (int i = 0; i < gameObjectDependency.Count; i++)
            {
                gameObjectDependency[i].SetActive(state);
            }
        }

        public void SwitchServiceState()
        {
            SetServiceState(!currentServiceState);
        }
    }
}