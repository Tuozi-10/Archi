
using UnityEngine;

namespace DefaultNamespace
{
    public class entitySO
    {
        public int hp { get; private set; } = 100;
        public Vector3 ressourceTarget;

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
