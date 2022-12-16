namespace Service
{
    public interface ISceneService : IService
    {
        void LoadScene(int sceneIndex);

        void LoadScene(string sceneName);
    }
}
