using Attributes;
using Service.AudioService;

namespace Service
{
    public class GameService : SwitchableService, IGameService
    {
        [DependsOnService] private IAudioService _audioService;
        [DependsOnService] private ISceneService _sceneService;
        [DependsOnService] private IFightService _fightService;
        [DependsOnService] private IUIService _uiService;
        [DependsOnService] private IEntitiesFactoryService _entitiesFactoryService;

        private bool isEnabled;
        
        [ServiceInit]
        private void Initialize()
        {
            // _audioService.PlaySound(0);
            _sceneService.LoadScene("FirstScene");
            _uiService.DisplayMainMenu();
            // _uiService.CallPopup();
            _entitiesFactoryService.Initialize();
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger", GenerateBurger);
            // AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeCanvas", GenerateCanvas);
        }

        // private void GenerateCanvas(GameObject gameObject)
        // {
        //     var canvas = Object.Instantiate(gameObject);
        //     canvas.GetComponent<ChangeScene>().Setup(m_sceneService, m_fightService);
        //     Release(gameObject);
        // }

        private void Switch()
        {
            
        }

        private void Enable()
        {
            base.Enable();
        }

        private void Disable()
        {
            base.Disable();
        }
    }
}