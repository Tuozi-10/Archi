using Service;

namespace DesignPatterns
{
    public class EntityCreatorEvent
    {
        public IEntitiesFactoryService factory;

        public EntityCreatorEvent(IEntitiesFactoryService fac)
        {
            factory = fac;
        }
    }
}