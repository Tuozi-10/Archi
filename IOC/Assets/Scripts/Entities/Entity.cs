using DesignPattern;

namespace DefaultNamespace
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