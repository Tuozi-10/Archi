using Service;
using UnityEngine;

public interface IEntitiesFactoryService : IService
{
    void CreateHarvester();
    void CreateLumberjack();
    void CreateBlacksmith();
}
