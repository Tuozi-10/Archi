using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Service;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button midTopButton;
    [SerializeField] Button midMidButton;
    [SerializeField] Button midDownButton;
    [SerializeField] Button toggle;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] private RectTransform leftMenu;
    [SerializeField] private RectTransform middleMenu;
    [SerializeField]
    private Button leftMenuOutButton;
    [SerializeField]
    private Button leftButton;
    
    public void Init(IUICanvasSwitchableService uiCanvasService,  IGameService sceneService)
    {
        midTopButton.onClick.AddListener(sceneService.LoadGame); 
        
        toggle.onClick .AddListener(new UnityAction((() =>
        {
            if (uiCanvasService.GetIsActiveService)
            {
                uiCanvasService.DisabledService();
            }
            else
            {
                uiCanvasService.EnabledService();
            }
        })));
    }

    public void OpenLeftMenu()
    {
        leftButton.gameObject.SetActive(false);
        leftMenu.DOAnchorPosX(leftMenu.rect.width,1f).OnComplete(()=>leftMenuOutButton.gameObject.SetActive(true));
    }
    public void CloseLeftMenu()
    {
        leftMenuOutButton.gameObject.SetActive(false);
        leftMenu.DOAnchorPosX(0,1f ).OnComplete(() => { leftButton.gameObject.SetActive(true);});
    }
    
    
}
