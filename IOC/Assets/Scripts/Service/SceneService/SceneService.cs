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
    
    [ServiceInit]
    private void Initialize()
    {
        LoadScene(2);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Canvas", (obj) =>
        {
            var canvas = Object.Instantiate(obj);
            canvas.name = "Canvas";
            canvas.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => m_gameService.ShowBurger()); 
            canvas.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => LoadScene(1)); 
        });

    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
