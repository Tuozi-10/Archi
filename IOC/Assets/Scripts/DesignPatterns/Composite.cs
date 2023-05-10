using System;
using System.Collections.Generic;
using Dp.DesignPatterns;
using UnityEngine;

namespace Dp.DesignPatterns
{
    public class Composite : MonoBehaviour
    {
        private List<IComponent> m_components = new List<IComponent>();

        private void Awake()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            foreach (var component in m_components)
            {
                component.Init();
            } 
        }

        public void AddComponent(IComponent component)
        {
            m_components.Add(component);
            component.Init();
        }

        public IComponent GetComponent(IComponent type)
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