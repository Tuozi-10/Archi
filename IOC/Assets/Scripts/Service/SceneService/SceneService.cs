using UnityEngine.SceneManagement;

namespace Service.SceneService
{
    public class SceneService : ISceneService
    {
        public void LoadScene(string key)
        {
            SceneManager.LoadScene(key);
        }

        public void LoadScene(uint index)
        {
            SceneManager.LoadScene((int)index);
        }
    }
}
