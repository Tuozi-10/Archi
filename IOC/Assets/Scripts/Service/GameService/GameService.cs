using Addressables;
using Attributes;
using Service.AudioService;
using Service.SceneService;
<<<<<<< HEAD
using Service.UIService;
using UI;
=======
>>>>>>> 3f2ccdb... Gotgot commit
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] private IAudioService m_audioService;
<<<<<<< HEAD
        [DependsOnService] private ISceneService m_sceneService;
        [DependsOnService] private IUIService m_uiService;
=======

        [DependsOnService] private ISceneService m_sceneService;
>>>>>>> 3f2ccdb... Gotgot commit

        [ServiceInit]
        private void Initialize()
        {
<<<<<<< HEAD
           m_audioService.PlaySound(0);
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
           AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UI", GenerateUI);
           m_sceneService.LoadScene("UI");
           
=======
            m_audioService.PlaySound(0);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LoadSceneCanvas", GenerateCanvas);
            m_sceneService.LoadScene(1);
>>>>>>> 3f2ccdb... Gotgot commit
        }

        private void GenerateCanvas(GameObject canvas)
        {
            var loadSceneCanvas = Object.Instantiate(canvas);
<<<<<<< HEAD
            loadSceneCanvas.GetComponent<LoadSceneCanvasManager>().AssignService(this);
            Release(canvas);
        }

        public void InitializeInGameScene()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameCanvas", GenerateInGameCanvas);
            m_sceneService.LoadScene(2);
        }
        
        private void GenerateInGameCanvas(GameObject canvas)
        {
            var inGameCanvas = Object.Instantiate(canvas);
            inGameCanvas.GetComponent<InGameCanvas>().AssignService(m_uiService);
            Release(canvas);
        }
=======
            loadSceneCanvas.GetComponent<LoadSceneCanvasManager>().AssignService(m_sceneService);
            Release(canvas);
        }
>>>>>>> 3f2ccdb... Gotgot commit
    }
}