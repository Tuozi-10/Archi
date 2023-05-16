using DesignPattern;

namespace Entities
{
    public class Entity : Composite
    {
        public EntitySO Data;

        public Entity(EntitySO data)
        {
            Data = data;
        }
    }
}