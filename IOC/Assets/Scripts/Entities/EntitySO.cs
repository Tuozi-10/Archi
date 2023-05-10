using DefaultNamespace;
using UnityEngine;

public class EntitySO : ScriptableObject
{
        public int hp { get; private set; }
        
        protected Entity m_entity;
        public ResourcesSO targetResources;

        public void SetEntity (Entity entity)
        {
                m_entity = entity;
        }
        
        // Entity GetEntity()
        // {
        //         return m_entity;
        // }
}