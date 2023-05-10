using entities;

namespace Service
{
    public interface IEntitiesFactoryService : IService, ISwitchableService
    {
        void CreateHarvester();
        void CreateLumberjack();
    }
}