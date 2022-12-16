using Addressables;
using Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Service.SceneService
{
    public class SceneService : ISceneService
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("New Scene");
            

        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}