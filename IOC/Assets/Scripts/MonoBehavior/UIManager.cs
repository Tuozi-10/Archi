using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Service;
using Service.SceneService;
using Service.UIService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    #region Service
    private ISceneService m_sceneService;
    private IGameService m_gameService;
    private IUIService m_UIService;

    public void Setup( ISceneService sceneService, IUIService UIService, IGameService gameService)
    {
        m_sceneService = sceneService;
        m_UIService = UIService;
        m_gameService = gameService;
    }
    #endregion

    [SerializeField] private RectTransform barMenu;
    [SerializeField] private Transform displaybarMenuButton;

    private Vector3 barMenuPos;

    private void Start()
    {
        barMenuPos = barMenu.anchoredPosition;
    }

    public void ShowbarMenu()
    {
        barMenu.DOAnchorPos(Vector3.zero, .5f).SetEase(Ease.OutBack);
        displaybarMenuButton.DOScale(Vector3.zero, .15f).OnComplete(() => displaybarMenuButton.gameObject.SetActive(false));
    }

    public void HideBarMenu()
    {
        barMenu.DOAnchorPos(barMenuPos, .5f).OnComplete(() =>
        {
            displaybarMenuButton.gameObject.SetActive(true);
            displaybarMenuButton.DOScale(Vector3.one, .15f).SetEase(Ease.OutBack);
        });
    }
    
    public void LoadScene(string sceneName)
    {
        m_sceneService.LoadScene(sceneName);
    }

    public void DisableGameService()
    {
        m_gameService.SetServiceState(false);
    }
    
    public void SwitchGameService()
    {
        m_gameService.SwitchServiceState();
    }
}
