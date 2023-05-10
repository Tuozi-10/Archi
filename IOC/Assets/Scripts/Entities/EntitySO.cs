using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "EntitySO", fileName = "new EntitySO")]
    public class EntitySO : ScriptableObject
    {
        public int Health;
        public int Speed;
        public int Quantity;
        public int HarvestTime;
        public GameObject PrefabEntity;

        Entity GetEntity()
        {
            return new Entity(this);
        }
    }
}