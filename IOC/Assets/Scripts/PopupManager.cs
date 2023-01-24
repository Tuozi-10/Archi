using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Image popupImage;
    public Button popupCancel;

    public void Setup()
    {
        popupCancel.onClick.AddListener(CancelPopup);
        MenuManager.OnErrorFound += DisplayPopup;
    }
    
    public void DisplayPopup()
    {
        popupImage.rectTransform.DOKill();
        popupImage.rectTransform.DOAnchorPosY(-100,0.25f).SetEase(Ease.OutBack);
    }

    public void CancelPopup()
    {
        popupImage.rectTransform.DOKill();
        popupImage.rectTransform.DOAnchorPosY(400f, 0.25f).SetEase(Ease.OutBack);
    }
}
