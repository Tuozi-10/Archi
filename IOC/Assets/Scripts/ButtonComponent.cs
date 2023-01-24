using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        DOTween.Kill(transform);
        transform.DOScale(2, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill(transform); 
        transform.DOScale(1, 0.5f);
    }
}
