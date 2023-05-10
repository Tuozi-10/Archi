using UnityEngine;

namespace _2
{
    public class entitySO : ScriptableObject
    {
        public int speed { get; private set; }
        public int actionSpeed { get; private set; }

        entity GetEntity()
        {
            return new entity(this);
        }
    }
    
    public class entity
    {
        public int speed;
        public int actionSpeed;
        
        public entity(entitySO so)
        {
            speed = so.speed;
            actionSpeed = so.actionSpeed;
        }
    }
}