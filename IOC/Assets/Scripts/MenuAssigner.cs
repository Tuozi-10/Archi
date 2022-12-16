using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuAssigner : MonoBehaviour
{
    [SerializeField] private Button toggleSceneService;
    [SerializeField] private Button changeSceneButton;
    [SerializeField] private TextMeshProUGUI toggleText;
    private bool isEnabled;

    private void Start()
    {
        toggleSceneService.onClick.AddListener(()=>isEnabled=!isEnabled);
        toggleSceneService.onClick.AddListener(ChangeText);
    }

    private void ChangeText()
    {
        toggleText.text = isEnabled ? "enabled" : "disabled";
    }

    public void AssignToggleButtonMethod(Action action,bool value)
    {
        toggleSceneService.onClick.AddListener(()=>action?.Invoke());
        isEnabled = value;
        ChangeText();
    }

    public void AssignSceneButtonMethod(Action action)
    {
        changeSceneButton.onClick.AddListener(()=>action?.Invoke());
    }
}
