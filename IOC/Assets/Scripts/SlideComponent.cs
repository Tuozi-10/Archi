using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Vector2 hidePos;
    public Vector2 showPos;
    
    public Color showColor;
    public Color hideColor;
    
    private RectTransform rect;
    private bool isLocked;
    private Image image;
    
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isLocked) return;
        
        DOTween.Kill(transform);
        rect.DOAnchorPos(showPos, 1).SetEase(Ease.OutBack, 0.2f);
        image.DOColor(showColor, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isLocked) return;
        DOTween.Kill(transform);
        rect.DOAnchorPos(hidePos, 1).SetEase(Ease.InBack, 0.2f);
        image.DOColor(hideColor, 0.5f);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Logs.Log("UI DEBUG", isLocked.ToString(), LogType.Log, Logs.LogColor.Green, Logs.LogColor.None);
        isLocked = !isLocked;    
    }
}
