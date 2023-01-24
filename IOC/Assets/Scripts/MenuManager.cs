using Attributes;
using DG.Tweening;
using Service;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Button buttonHide;
    [SerializeField] private Button buttonToggle;
    [SerializeField] private Button buttonHideMenu;
    [SerializeField] private Button popupButton;
    [SerializeField] private Image imageMenu;
    
    [DependsOnService]
    private ISceneService m_sceneService;
    [DependsOnService]
    private IFightService m_fightService;
    [DependsOnService] 
    private IUIService m_uiService;
    
    public void Setup(ISceneService sceneService, IFightService fightService)
    {
        m_sceneService = sceneService;
        button.onClick.AddListener(() => m_sceneService.LoadScene("SecondScene"));
        m_fightService = fightService;
        buttonHide.onClick.AddListener(() => m_fightService.Toggle());
        buttonToggle.onClick.AddListener(OpenLeftMenu);
        buttonHideMenu.onClick.AddListener(HideLeftMenu);
        popupButton.onClick.AddListener(CreateError);
    }

    private void HideLeftMenu()
    {
        buttonHideMenu.transform.DOKill();
        buttonHideMenu.transform.DOScale(0.75f, 0.25f).SetEase(Ease.OutBack).OnComplete(() => buttonHideMenu.transform.DOScale(1f, 0.25f));
        buttonToggle.transform.DOKill();
        buttonToggle.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);
        imageMenu.rectTransform.DOMoveX(-800f, 0.25f).SetEase(Ease.OutBack);
    }

    private void OpenLeftMenu()
    {
        buttonToggle.transform.DOKill();
        buttonToggle.transform.DOScale(0f, 0.25f).SetEase(Ease.OutBack);
        imageMenu.rectTransform.DOMoveX(0f, 0.25f).SetEase(Ease.OutBack);
    }

    private void CreateError()
    {
        OnErrorFound?.Invoke();
    }
    
    public delegate void NoParameterDelegate();
    public static event NoParameterDelegate OnErrorFound;
}
