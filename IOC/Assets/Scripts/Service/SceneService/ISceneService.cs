using UnityEngine;

namespace Service.SceneService
{
    public interface ISceneService : IService
    {
        public void LoadScene();
        public void LoadScene(string name);
    }
    
    
}