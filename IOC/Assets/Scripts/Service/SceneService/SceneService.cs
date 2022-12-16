using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SceneService : ISceneService
{
    public void LoadScene(int sceneKey)
    {
        SceneManager.LoadScene(sceneKey);
    }

    public void LoadScene(string sceneKey)
    {
        SceneManager.LoadScene(sceneKey);
    }
}
