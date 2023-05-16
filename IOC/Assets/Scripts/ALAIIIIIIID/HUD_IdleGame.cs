using System.Collections;
using System.Collections.Generic;
using Addressables;
using ALAIIIIIIID;
using Attributes;
using DG.Tweening;
using Service;
using UnityEngine;

public class HUD_IdleGame : IUIService
{
        [DependsOnService] private IIdleGame_Service m_idleGameService;
        
        private GameObject mainMenu = null;
        private bool isLoading = false;
        
        private RectTransform panel = null;

        private Queue<GameObject> pool = new Queue<GameObject>();

        private GameObject root = null;

        private UI_Idle_Game _uiIdleGame = null;

        public void LoadUI()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Canvas2", CreateUI);
        }

        public void CallPopUpGeneric<T>() where T : Object
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<T>("Pop", AddToQueue);
        }

        private void AddToQueue<T>(T obj) where T : Object
        {
        }

        private void Reshow()
        {
            root.SetActive(false);
        }

        public GameObject GetFromPool()
        {
            if (pool.Count > 0)
            {
                GameObject go = pool.Dequeue();
                go.SetActive(true);
                root = go;
                return go;
            }
            else
            {
                return null;
            }
        }
        

        private void CreateUI(GameObject UI)
        {
             mainMenu = Object.Instantiate(UI);
             mainMenu.SetActive(true);

             _uiIdleGame = mainMenu.GetComponent<UI_Idle_Game>();
             _uiIdleGame.m_idleGameService = m_idleGameService;
        }

        public UI_Idle_Game GetTextManager()
        {
            return _uiIdleGame;
        }

        public void ShowUIMainMenu()
        {
            if (!mainMenu)
            {
                if (isLoading) return;
                LoadUI();
            }
        }

        public void HideUIInGame()
        {
            
        }
}
