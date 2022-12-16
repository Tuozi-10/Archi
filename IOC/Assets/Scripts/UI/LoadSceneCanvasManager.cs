using System.Collections;
using System.Collections.Generic;
using Attributes;
using Service;
using Service.AudioService;
using Service.SceneService;
using UnityEngine;

public class LoadSceneCanvasManager : MonoBehaviour
{
    [DependsOnService] private ISceneService m_sceneService;

    public void AssignService(ISceneService service)
    {
        m_sceneService = service;
    }
    
    public void OnPlay()
    {
        m_sceneService.LoadScene(2);
    }
}
