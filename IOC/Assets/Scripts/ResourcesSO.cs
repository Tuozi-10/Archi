using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(order = 0, menuName = "Resources", fileName = "Resource")]
    public class ResourcesSO : ScriptableObject
    {
        public string resourceName;
        public int maxStack;

        public ResourcesSO(int maxStack)
        {
            this.maxStack = maxStack;
        }
    }
}