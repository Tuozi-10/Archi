using UnityEngine;

namespace Entities.Resources
{
    [CreateAssetMenu(menuName = "EntitySO", fileName = "new EntitySO")]
    public class ResourceSO : ScriptableObject
    {
        public int Quantity;
        public GameObject PrefabResource;
        
        Resource GetResource()
        {
            return new Resource(this);
        }
    }
}