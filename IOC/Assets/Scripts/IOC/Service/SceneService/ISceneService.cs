using Service;
using UnityEngine.SceneManagement;

public interface ISceneService : ISwitchableService
{
    void LoadScene(string sceneName);

    void LoadScene(int sceneIndex);
}
