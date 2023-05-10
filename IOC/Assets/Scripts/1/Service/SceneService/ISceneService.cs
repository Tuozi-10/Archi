using Service;

namespace Service.SceneService
{
    public interface ISceneService : IService
    {
        void LoadScene(string key);
        void LoadScene(uint index);
    }
}
