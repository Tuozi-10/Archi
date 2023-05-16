namespace Service
{
    public interface IEntitiesFactoryService : IService
    {
        void Initialize();
        void CreateHarvester();
        void CreateLumberjack();
        void CreateEntityEvent(CreateEvent createEvent);
    }
}