using System;
using System.Collections.Generic;

using UnityEngine;

namespace Components
{
    public class Composite : MonoBehaviour
    {
        
        private List<Component> m_components = new List<Component>();

        public Component AddComponent(Component component)
        {
            m_components.Add(component);
            return component;

        }
        

        public Component GetComponent(Component type)
        {
            // TODO
            return null;
        }
        
        public void Update()
        {
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            foreach (var component in m_components)
            {
                component.Update();
            }
        }
    }
}