using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuAssigner : MonoBehaviour
{
    [SerializeField] private Toggle toggleSceneService;
    [SerializeField] private Button changeSceneButton;

    public void AssignToggleMethod(Action<bool> action)
    {
        toggleSceneService.onValueChanged.AddListener((value) => action?.Invoke(value));
    }

    public void AssignButtonMethod(Action action)
    {
        changeSceneButton.onClick.AddListener(()=>action?.Invoke());
    }
}
