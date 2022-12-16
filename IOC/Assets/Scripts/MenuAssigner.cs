using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuAssigner : MonoBehaviour
{
    [SerializeField] private Button button;

    public void AssignButtonMethod(Action action)
    {
        button.onClick.AddListener(()=>action?.Invoke());
    }
}
