using Service;
using UnityEngine.SceneManagement;

public interface ISceneService : IService
{
    void LoadScene(string sceneName);

    void LoadScene(int sceneIndex);
}
