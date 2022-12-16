﻿using Addressables;
using Attributes;
using Service.AudioService;
using Service.FightService;
using Service.SceneService;
using Service.TickableService;
using Service.UIService;
using UI;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        [DependsOnService] private IAudioService m_audioService;
        [DependsOnService] private ISceneService m_sceneService;
        [DependsOnService] private IUIService m_uiService;
        [DependsOnService] private ITickableService m_tickableService;
        [DependsOnService] private IFightService m_fightService;

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
            loadSceneCanvas.GetComponent<LoadSceneCanvasManager>().AssignService(this);
            Release(canvas);
        }

        public void InitializeInGameScene()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameCanvas", GenerateInGameCanvas);
            m_sceneService.LoadScene(2);
            m_fightService.Enable();
            m_tickableService.Enable();
        }
        
        private void GenerateInGameCanvas(GameObject canvas)
        {
            var inGameCanvas = Object.Instantiate(canvas);
            inGameCanvas.GetComponent<InGameCanvas>().AssignService(m_uiService);
            Release(canvas);
        }
    }
}