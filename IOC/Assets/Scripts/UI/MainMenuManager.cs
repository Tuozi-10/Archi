using System;
using DG.Tweening;
using Service.UIService;
using UnityEngine;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        private IUIService m_uiService;
        [SerializeField] private RectTransform sideMenu;
        private bool isOpened;
        public Vector2 minMaxSideMenuPosX;
        [SerializeField] private RectTransform[] sideMenuButtons;

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
            
            if(isOpened) sideMenu.DOAnchorPosX(minMaxSideMenuPosX.x, .5f).SetEase(Ease.OutBack).OnComplete((() =>
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
    }
}