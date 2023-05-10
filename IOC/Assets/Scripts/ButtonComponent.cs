using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonComponent: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOAnchorPosX(30, 05f);
        transform.DOKill();
        transform.DOScale(1.1f, 0.25f).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(0.95f, 0.25f).OnComplete(() =>
        {
            transform.DOScale(1, 0.25f);
        });
    }
}