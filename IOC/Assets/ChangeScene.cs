using System;
using Attributes;
using Service;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button button;
    
    [DependsOnService]
    private ISceneService m_sceneService;

    public void Setup(ISceneService sceneService)
    {
        m_sceneService = sceneService;
        button.onClick.AddListener(() => m_sceneService.LoadScene("SecondScene"));
    }
}
