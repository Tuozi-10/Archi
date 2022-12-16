using System.Collections;
using System.Collections.Generic;
using Attributes;
using Service;
using Service.AudioService;
using Service.SceneService;
using UnityEngine;

public class LoadSceneCanvasManager : MonoBehaviour
{
    [DependsOnService] private IGameService m_gameService;

    public void AssignService(IGameService gs)
    {
        m_gameService = gs;
    }
    
    public void OnPlay()
    {
        m_gameService.InitializeInGameScene();
    }
}
