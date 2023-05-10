using entities;

namespace Service
{
    public interface IEntitiesFactoryService : IService
    {
        Entity CreateHarvester();
        Entity CreateLumberjack();
    }
}