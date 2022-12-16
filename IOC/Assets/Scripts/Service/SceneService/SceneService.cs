using UnityEngine.SceneManagement;

namespace Service.SceneService
{
    public class SceneService : SwitchableService, ISceneService
    {
        public void LoadScene(int sceneIndex)
        {
            if(!isEnabled) return;
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(string sceneName)
        {
            if(!isEnabled) return;
            SceneManager.LoadScene(sceneName);
        }
    }
}




