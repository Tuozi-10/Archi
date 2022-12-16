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
        [DependsOnService] private IAudioService m_audioService;

        [DependsOnService] private ISceneService m_sceneService;

        [ServiceInit]
        private void Initialize()
        {
            m_audioService.PlaySound(0);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LoadSceneCanvas", GenerateCanvas);
            m_sceneService.LoadScene(1);
        }

        private void GenerateCanvas(GameObject canvas)
        {
            var loadSceneCanvas = Object.Instantiate(canvas);
            loadSceneCanvas.GetComponent<LoadSceneCanvasManager>().AssignService(m_sceneService);
            Release(canvas);
        }
    }
}