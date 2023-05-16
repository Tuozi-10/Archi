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

        private void Switch()
        {
            
        }

        private void Enable()
        {
            base.Enable();
        }

        private void Disable()
        {
            base.Disable();
        }
    }
}
