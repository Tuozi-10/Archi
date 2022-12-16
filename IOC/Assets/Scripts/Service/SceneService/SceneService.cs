<<<<<<< HEAD
﻿using Unity.VisualScripting;
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
=======
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
>>>>>>> 3f2ccdb... Gotgot commit
