using System;
using System.Collections.Generic;

using UnityEngine;

namespace Components
{
    public class Composite : MonoBehaviour
    {
        
        private List<Component> _allComponents = new List<Component>();

        public T AddComponent<T>(T component) where T : Component
        {
            _allComponents.Add(component);
            return component;

        }
        

        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < _allComponents.Count; i++)
            {
                if (_allComponents[i] is T componentValided)
                {
                    return componentValided;
                }
            }
            return null;
        }
        
        public void Update()
        {
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            foreach (var component in _allComponents)
            {
                component.TryUpdate();
            }
        }
    }
}