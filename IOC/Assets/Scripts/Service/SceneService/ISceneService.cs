namespace Service.SceneService
{
    public interface ISceneService : ISwitchableService
    {
        public void LoadScene(int sceneIndex);
        public void LoadScene(string sceneName);
    }
}


