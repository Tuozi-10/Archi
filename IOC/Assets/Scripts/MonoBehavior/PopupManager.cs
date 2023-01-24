using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private List<PopUpSO> startPopup;
    private Queue<PopUpSO> popupQueue = new();

    
     private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform popupBox;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    private bool isDisplay;

    private void Start()
    {
        popupBox.gameObject.SetActive(false);
        canvasGroup = popupBox.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        popupBox.localScale = Vector3.zero;
        foreach (var popup in startPopup)
        {
            popupQueue.Enqueue(popup);
        }
        UpdatePopup();
    }

    void UpdatePopup()
    {
        if (isDisplay && popupQueue.Count == 0) return;
        var popup = popupQueue.Dequeue();
        DisplayPopup(popup);
    }

    void AddPopup(PopUpSO popup)
    {
        popupQueue.Enqueue(popup);
        UpdatePopup();
    }
    
    void DisplayPopup(PopUpSO popup)
    {
        popupBox.gameObject.SetActive(true);
        image.sprite = popup.image;
        titleText.text = popup.title;
        descriptionText.text = popup.description;
        canvasGroup.DOFade(1, .5f-.2f).SetDelay(.2f);
        popupBox.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
    }

    public void DisablePopup()
    {
        canvasGroup.DOFade(0, .4f-.225f).SetDelay(.225f);
        popupBox.DOScale(Vector3.zero, .5f).SetEase(Ease.InBack).OnStepComplete(() =>
        {
            isDisplay = false;
            popupBox.gameObject.SetActive(false);
            UpdatePopup();
        });
    }
}
