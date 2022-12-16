using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Service.AudioService;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class UICanvasService : IUICanvasSwitchableService
    {
        [DependsOnService] private ISceneService _sceneService;

        [DependsOnService] private ITickeableSwitchableService tickeableService;
        private bool isActive;
        private GameObject canvas;
        public void LinkButton()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UICanvas", GenerateCanvas);
        }

        private void GenerateCanvas(GameObject gameObject)
        {
           var canvasObject = Object.Instantiate(gameObject);
            var linker = canvasObject.GetComponent<CanvasLinker>();
            canvas = linker.mainCanvas;
            linker.button.onClick
                .AddListener(new UnityAction((() => { _sceneService.LoadScene("ThirdScene"); })));
            linker.toggle.onClick .AddListener(new UnityAction((() =>
            {
                if (GetIsActiveService)
                {
                    DisabledService();
                    tickeableService.DisabledService();
                }
                else
                {
                    EnabledService();
                    tickeableService.EnabledService();
                }
            })));
            EnabledService();
            Release(gameObject);
        }

        public void EnabledService()
        {
            isActive = true;
            canvas.SetActive(true);
        }
        public void DisabledService()
        {
            isActive = false;
            canvas.SetActive(false);
        }
        public bool GetIsActiveService => isActive;
        
    }
}