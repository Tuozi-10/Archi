using System.Collections;
using System.Collections.Generic;
using Addressables;
using DG.Tweening;
using Service;
using UnityEngine;

public class WarcraftHUD : IUIService
{
        private GameObject mainMenu = null;
        private bool isLoading = false;
        
        private RectTransform panel = null;

        private Queue<GameObject> pool = new Queue<GameObject>();

        private GameObject root = null;

        private UI_Warcraft uiWarcraft = null;

        public void LoadUI()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UIWarcraft", CreateUI);
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
            return null;
        }
        

        private void CreateUI(GameObject UI)
        {
            mainMenu = Object.Instantiate(UI);
            mainMenu.SetActive(true);

             uiWarcraft = mainMenu.GetComponent<UI_Warcraft>();
        }

        public UI_Warcraft GetTextManager()
        {
            return uiWarcraft;
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
