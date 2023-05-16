using UnityEngine;

namespace Entities.Resources
{
    [CreateAssetMenu(menuName = "ResourceSO", fileName = "new ResourceSO")]
    public class ResourceSO : ScriptableObject
    {
        public int Quantity;
        public GameObject PrefabResource;
        
        Resource GetResource()
        {
            return new Resource(Quantity, this);
        }
    }
}