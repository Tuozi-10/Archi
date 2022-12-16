using System.Collections.Generic;
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

        private List<GameObject> gameObjectDependency = new List<GameObject>();

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
           m_sceneService.LoadScene("New Scene");
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger); 
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UI", CreateUI); 
           //AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Cubator", );
        }

        private void GenerateBurger(GameObject gameObject)
        {
            var burger = Object.Instantiate(gameObject);
            gameObjectDependency.Add(burger);
            Release(gameObject);
        }

        private void CreateUI(GameObject gameObject)
        {
            var UI = Object.Instantiate(gameObject);
            gameObjectDependency.Add(UI);
            UI.GetComponent<UIManager>().Setup(m_sceneService, this);
        }

        public void SwitchServiceState(bool state)
        {
            for (int i = 0; i < gameObjectDependency.Count; i++)
            {
                gameObjectDependency[i].SetActive(state);
            }
        }
    }
}