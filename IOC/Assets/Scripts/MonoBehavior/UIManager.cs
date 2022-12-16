using System.Collections;
using System.Collections.Generic;
using Service.SceneService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private ISceneService m_sceneService;

    public void Setup( ISceneService sceneService)
    {
        m_sceneService = sceneService;
    }
    
    public void LoadScene(string sceneName)
    {
        m_sceneService.LoadScene(sceneName);
    }
}
