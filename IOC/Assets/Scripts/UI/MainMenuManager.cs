using System;
using Addressables;
using DG.Tweening;
using Service.UIService;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        private IUIService m_uiService;
        [SerializeField] private RectTransform sideMenu;
        private bool isOpened;
        public Vector2 minMaxSideMenuPosX;
        [SerializeField] private RectTransform[] sideMenuButtons;
        [SerializeField] private RectTransform popUpPos;
        public PopUp currentPopUp;

        public void GeneratePopUps()
        {
            for (int i = 0; i < 5; i++)
            {
                var data = new PopUp.PopUpData()
                {
                    message = $"Pop-Up {Random.Range(1, 1000)}",
                    color = Random.ColorHSV()
                };
                AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("PopUp",
                    popUp => GenerateSinglePopUp(popUp, data));
            }
        }

        public void AssignService(IUIService service)
        {
            m_uiService = service;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Play()
        {
            Logs.Log("Played!");
        }

        public void OpenSideMenu()
        {
            Logs.Log("Opened side menu!");

            isOpened = !isOpened;

            if (isOpened)
                sideMenu.DOAnchorPosX(minMaxSideMenuPosX.x, .5f).SetEase(Ease.OutBack).OnComplete((() =>
                {
                    foreach (var rt in sideMenuButtons)
                    {
                        rt.DOScale(1, .1f);
                    }
                }));
            else
            {
                for (int i = 0; i < sideMenuButtons.Length - 1; i++)
                {
                    sideMenuButtons[i].DOScale(0, .1f);
                }

                sideMenuButtons[^1].DOScale(0, .1f).OnComplete((() =>
                {
                    sideMenu.DOAnchorPosX(minMaxSideMenuPosX.y, .5f).SetEase(Ease.InBack);
                }));
            }
        }

        private void GenerateSinglePopUp(GameObject go, PopUp.PopUpData data)
        {
            var instance = Instantiate(go, Vector3.zero, Quaternion.identity, transform);
            instance.GetComponent<RectTransform>().position = popUpPos.position;
            var popUp = instance.GetComponent<PopUp>();
            popUp.data = data;
            popUp.SetText(this);
            popUp.gameObject.SetActive(false);
            m_uiService.AddPopUpToQueue(popUp);
        }

        public void OnNextPopUpClick()
        {
            if (!currentPopUp)
            {
                Debug.LogWarning("There's no current pop-up!");
            }
            else
            {
                currentPopUp.transform.DOScale(0, .1f).OnComplete((() => { currentPopUp.gameObject.SetActive(false); }))
                    .OnComplete(m_uiService.DisplayNextPopUp);
                currentPopUp = null;
            }
        }

        public void DisplayPopUp(PopUp popUp)
        {
            currentPopUp = popUp;
            currentPopUp.gameObject.SetActive(true);
            currentPopUp.transform.localScale = Vector3.zero;
            currentPopUp.transform.DOScale(1, .1f).SetEase(Ease.InBack);
        }
    }
}