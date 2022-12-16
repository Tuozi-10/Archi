using UnityEngine.SceneManagement;

namespace Service.SceneService
{
    public class SceneService : ISceneService
    {
        
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}




