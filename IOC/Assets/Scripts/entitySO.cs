using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Entity", fileName = "new entity")]
    public class entitySO : ScriptableObject
    {
        public int hp { get; private set; }
        public int maxWood, maxStone;
    }
}