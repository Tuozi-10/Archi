using System;
using System.Collections.Generic;
using Dp.DesignPatterns;
using JetBrains.Annotations;
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

        public T GetCompositeComponent<T>() where T : IComponent
        {
            foreach (var component in m_components)
            {
                if (component is T type) return type;
            }

            return default;
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