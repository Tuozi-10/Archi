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
    public class UICanvasService : IUICanvasService
    {
        [DependsOnService] private ISceneService _sceneService;
        
        public void LinkButton()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UICanvas", GenerateCanvas);
        }

        private void GenerateCanvas(GameObject gameObject)
        {
            var canvas = Object.Instantiate(gameObject);
            var linker = canvas.GetComponent<CanvasLinker>();
            linker.button.onClick
                .AddListener(new UnityAction((() => { _sceneService.LoadScene("ThirdScene");})));
            Release(gameObject);
        }
    }
}