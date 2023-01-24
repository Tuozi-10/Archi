using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(1.1f, .1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(1f, .1f);
    }
}
