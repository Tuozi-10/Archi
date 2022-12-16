using Service;

public interface ISceneService : IService
{

    void LoadScene(int sceneKey);


    void LoadScene(string sceneKey);

}
