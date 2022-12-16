using System.Collections;
using System.Collections.Generic;
using Attributes;
using Service;
using Service.AudioService;
using Service.SceneService;
using UnityEngine;

public class LoadSceneCanvasManager : MonoBehaviour
{
<<<<<<< HEAD
    [DependsOnService] private IGameService m_gameService;

    public void AssignService(IGameService gs)
    {
        m_gameService = gs;
=======
    [DependsOnService] private ISceneService m_sceneService;

    public void AssignService(ISceneService service)
    {
        m_sceneService = service;
>>>>>>> 3f2ccdb... Gotgot commit
    }
    
    public void OnPlay()
    {
<<<<<<< HEAD
        m_gameService.InitializeInGameScene();
=======
        m_sceneService.LoadScene(2);
>>>>>>> 3f2ccdb... Gotgot commit
    }
}
