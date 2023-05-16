using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using HelperPSR.Pool;
using HelperPSR.UI;
using Service.AudioService;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;

namespace Service
{
    public class UICanvasService : IUICanvasSwitchableService
    {
        [DependsOnService] private IGameService _gameService;

        [DependsOnService] public ITickeableSwitchableService tickeableService;

        
        Queue<PopUpData> popUpsNeededToPrint = new Queue<PopUpData>();

        PopUp currentPopUpPrinted;

        private bool isActive;

        private Pool<PopUp> popUpPool;

        private GameObject popUpCanvas;

        private GameObject popUpPrefab;

        private Action tempCallback; 

        public void LoadMainMenu()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("MainMenu", GenerateMainMenu);
        }

        public void LoadInGameMenu(Action callback)
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("InGameMenu", GenerateInGameMenu);
            tempCallback = callback;
        }
        public void LoadPopUpCanvas()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("PopUpCanvas", InitPopUpCanvas);
        }

        private void InitPopUpPool(GameObject gameObject)
        {
            popUpPool = new Pool<PopUp>(gameObject.GetComponent<PopUp>(), 10,
                (element) =>
                {
                    element.transform.SetParent(popUpCanvas.gameObject.transform);
                    RectTransform rectTransform = element.GetComponent<RectTransform>(); 
                    rectTransform.anchoredPosition = Vector2.zero;
                });
           
        }


        private void InitPopUpCanvas(GameObject gameObject)
        {
            popUpCanvas = Object.Instantiate(gameObject);
            Object.DontDestroyOnLoad(popUpCanvas);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("PopUp", InitPopUpPool);
        }

        public void EnqueuePopUpData(PopUpData popUpData)
        {
            popUpsNeededToPrint.Enqueue(popUpData);
        }

        private void DequeuePopUpData()
        {
            currentPopUpPrinted = popUpPool.GetFromPool().GetComponent<PopUp>();
            currentPopUpPrinted.InitPopUp(popUpsNeededToPrint.Dequeue(), EndPopUp);
        }

        private void EndPopUp(PopUp popUp)
        {
            popUpPool.AddToPool(popUp);
            currentPopUpPrinted = null;
            if (popUpsNeededToPrint.Count != 0) DequeuePopUpData();
        }

        private void GenerateMainMenu(GameObject gameObject)
        {
            var canvasObject = Object.Instantiate(gameObject);
            var mainMenuManager = canvasObject.GetComponent<MainMenuManager>();
            mainMenuManager.Init(this, _gameService);
            EnabledService();
            Release(gameObject);
        }
        
        private void GenerateInGameMenu(GameObject gameObject)
        {
            var canvasObject = Object.Instantiate(gameObject);
            tempCallback?.Invoke();
            Release(gameObject);
        }
        

        

        
        public void EnabledService(Action callback = null)
        {
            isActive = true;
        }

        public void DisabledService(Action callback = null)
        {
            isActive = false;
        }

     

        public bool GetIsActiveService => isActive;
    }
}