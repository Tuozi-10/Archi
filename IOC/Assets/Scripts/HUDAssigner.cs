using System;
using Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUDAssigner : MonoBehaviour
{
    [SerializeField] private Button harvesterButton;
    [SerializeField] private Button lumberjackButton;
    [SerializeField] private Button blacksmithButton;

    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneTxt;
    
    public void AssignHarvesterButton(UnityAction action)
    {
        harvesterButton.onClick.AddListener(action);
    }

    public void AssignLumberjackButton(UnityAction action)
    {
        lumberjackButton.onClick.AddListener(action);
    }

    public void AssignBlacksmithButton(UnityAction action)
    {
        blacksmithButton.onClick.AddListener(action);
    }

    public void UpdateWoodText(string text)
    {
        woodText.text = text;
    }

    public void UpdateStoneText(string text)
    {
        stoneTxt.text = text;
    }
}
