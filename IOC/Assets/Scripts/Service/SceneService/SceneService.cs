using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Service;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneService : ISceneService
{
    [DependsOnService] 
    private IGameService m_gameService;
    
    GameObject canvas;

    private bool SwitchState;
    
    [ServiceInit]
    private void Initialize()
    {
        SwitchState = false;
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Switch()
    {
      if (SwitchState)
          Enable();
      else
          Disable();
      SwitchState = !SwitchState;
    }

    public void Enable()
    {
        LoadScene(2);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Canvas", (obj) =>
        {
            GameObject canvas = Object.Instantiate(obj);
            canvas.name = "Canvas";
            canvas.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => m_gameService.ShowBurger()); 
            canvas.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => LoadScene(1)); 
        });
    }

    public void Disable()
    {
        Object.Destroy(canvas);
    }
}
