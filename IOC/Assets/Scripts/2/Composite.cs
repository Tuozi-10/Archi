using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _2
{
    public class Composite : MonoBehaviour
    {
        private List<IComponent> m_components = new();

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

        public T GetComponent<T>()
        {
            foreach (var component in m_components.OfType<T>())
            {
                return component;
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