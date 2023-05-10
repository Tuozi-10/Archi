using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scale = 1.5f;
    public float duration = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        DOTween.Kill(transform);
        transform.DOScale(scale, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill(transform); 
        transform.DOScale(1, duration);
    }
}
