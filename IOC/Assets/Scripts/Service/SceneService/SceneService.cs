using UnityEngine.SceneManagement;

namespace Service
{
    public class SceneService : SwitchableService, ISceneService
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        void Switch()
        {
            
        }

        void Enable()
        {
            base.Enable();
        }

        void Disable()
        {
            base.Disable();
        }
    }
}
