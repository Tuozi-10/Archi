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
            // GameObject.Instantiate(obj as GameObject);
            // log.Log(pool.Count.ToString());
            // GameObject go = (obj as GameObject);
            // Button btn = go.transform.GetChild(0).GetChild(0).GetComponent<Button>();
            // btn.onClick.AddListener(() =>
            // {
            //     Reshow();
            //     GetFromPool();
            // });
            // pool.Enqueue(obj as GameObject);
            // if (obj is GameObject t)
            //     t.SetActive(false);
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
            // show = mainMenu.transform.GetChild(2).GetComponent<Button>();
            // hide = mainMenu.transform.GetChild(3).GetComponent<Button>();
            // panel = mainMenu.transform.GetChild(1).GetComponent<RectTransform>();
            // nullBut = mainMenu.transform.GetChild(0).GetComponent<Button>();
            // show.onClick.AddListener(() => ShowUIMainMenu());
            // hide.onClick.AddListener(() => HideUIInGame());
            // //nullBut.onClick.AddListener(() => GetFromPool().transform.parent = mainMenu.transform);
             mainMenu.SetActive(true);
             log.Log("UI Loaded");

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
