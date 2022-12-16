namespace Service.SceneService
{
    public interface ISceneService : IService
    {
        public void LoadScene(int sceneIndex);
        public void LoadScene(string sceneName);
    }
}


