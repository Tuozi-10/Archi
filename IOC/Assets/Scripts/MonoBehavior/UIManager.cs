using System.Collections;
using System.Collections.Generic;
using Service;
using Service.SceneService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private ISceneService m_sceneService;
    private IGameService m_gameService;

    public void Setup( ISceneService sceneService, IGameService gameService)
    {
        m_sceneService = sceneService;
        m_gameService = gameService;
    }
    
    public void LoadScene(string sceneName)
    {
        m_sceneService.LoadScene(sceneName);
    }

    public void DisableGameService()
    {
        m_gameService.SwitchServiceState(false);
    }
}
