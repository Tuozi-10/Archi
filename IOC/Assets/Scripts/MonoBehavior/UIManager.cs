using System.Collections;
using System.Collections.Generic;
using Service;
using Service.SceneService;
using Service.UIService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private ISceneService m_sceneService;
    private IGameService m_gameService;
    private IUIService m_UIService;

    public void Setup( ISceneService sceneService, IUIService UIService, IGameService gameService)
    {
        m_sceneService = sceneService;
        m_UIService = UIService;
        m_gameService = gameService;
    }
    
    public void LoadScene(string sceneName)
    {
        m_sceneService.LoadScene(sceneName);
    }

    public void DisableGameService()
    {
        m_gameService.SetServiceState(false);
    }
    
    public void SwitchGameService()
    {
        m_gameService.SwitchServiceState();
    }
}
