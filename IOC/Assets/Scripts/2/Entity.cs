namespace _2
{
    public class Entity : Composite
    {
        // data for our entity, hp, gold, stone, wood, speed ... 
        private entitySO data;

        public Entity(entitySO data)
        {
            this.data = data;
        }

    }
}