using UnityEngine;

namespace DefaultNamespace
{
    public class entitySO : ScriptableObject
    {
        public int hp { get; private set; }

        entity GetEntity()
        {
            return new entity(this);
        }
    }
    
    public class entity
    {
        public int hp;
        
        public entity(entitySO so)
        {
            hp = so.hp;
        }
    }
}