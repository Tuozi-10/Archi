using System.Collections.Generic;
using System.Threading.Tasks;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Service.AudioService;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AddressableAssets.Addressables;


namespace Service
{
    public class UIService : IUIService
    {
        private GameObject mainMenu = null;
        private bool isLoading = false;

        private Button show = null;
        private Button hide = null;
        private Button nullBut = null;
        private RectTransform panel = null;

        private Queue<GameObject> pool = new Queue<GameObject>();
        
        private GameObject root = null;

        public void LoadUI()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UIMenu", CreateUI);
        }

        public void CallPopUpGeneric<T>() where T : Object
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<T>("Pop", AddToQueue);
        }

        private void AddToQueue<T>(T obj) where T : Object
        {
            GameObject.Instantiate(obj as GameObject);
            log.Log(pool.Count.ToString());
            GameObject go = (obj as GameObject);
            Button btn = go.transform.GetChild(0).GetChild(0).GetComponent<Button>();
            btn.onClick.AddListener(() => { Reshow(); GetFromPool(); });
            pool.Enqueue(obj as GameObject);
            if (obj is GameObject t)
                t.SetActive(false);
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

        private async void oui()
        {
            await UniTask.Delay(2000);
            GetFromPool();
        }

        private void CreateUI(GameObject UI)
        {
            mainMenu = Object.Instantiate(UI);
            show = mainMenu.transform.GetChild(2).GetComponent<Button>();
            hide = mainMenu.transform.GetChild(3).GetComponent<Button>();
            panel = mainMenu.transform.GetChild(1).GetComponent<RectTransform>();
            nullBut = mainMenu.transform.GetChild(0).GetComponent<Button>();
            show.onClick.AddListener(() => ShowUIMainMenu());
            hide.onClick.AddListener(() => HideUIInGame());
            //nullBut.onClick.AddListener(() => GetFromPool().transform.parent = mainMenu.transform);
            mainMenu.SetActive(true);
            log.Log("UI Loaded");
            CallPopUpGeneric<Object>();
            CallPopUpGeneric<Object>();
            CallPopUpGeneric<Object>();
            oui();
        }

        public void ShowUIMainMenu()
        {
            if (!mainMenu)
            {
                if (isLoading) return;
                LoadUI();
            }
            else
            {
                panel.DOMoveX(100f, 0.5f).SetEase(Ease.OutBack);
                //nullBut.GetComponent<RectTransform>().DoAnchorPosX(20f, 0.5f).SetEase(Ease.OutBack);
                PrintBtn(true);
            }
        }

        private async void PrintBtn(bool activate)
        {
            if (activate)
                await UniTask.Delay(1000);
            panel.transform.GetChild(0).gameObject.SetActive(activate);
        }

        public void HideUIInGame()
        {
            if (!mainMenu) return;
            panel.DOMoveX(-305f, 0.5f).SetEase(Ease.InBack);
            //nullBut.GetComponent<RectTransform>().DoAnchorPosX(0f, 0.5f).SetEase(Ease.OutBack);
            PrintBtn(false);
        }
    }
}