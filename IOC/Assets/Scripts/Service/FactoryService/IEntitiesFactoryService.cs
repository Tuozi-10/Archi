using DefaultNamespace;
using Service;

public interface IEntitiesFactoryService : IService
{
    void Initialize();
    void CreateHarvester();
    void CreateLumberjack();
}
