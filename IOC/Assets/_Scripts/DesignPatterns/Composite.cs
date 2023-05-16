using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public class Composite : MonoBehaviour
    {
        private List<IComponent> _components = new();

        private void Awake()
        {
            if (_components is null) _components = new();
            InitComponents();
        }

        private void InitComponents()
        {
            foreach (var component in _components)
            {
                component.Init();
            } 
        }

        public void AddComponent(IComponent component)
        {
            if (_components is null) _components = new();
            _components.Add(component);
            component.Init();
        }

        public IComponent GetComponent<T>()
        {
            foreach (var component in _components)
            {
                if (component is T)
                {
                    return component;
                }
            }
            
            return default;
        }
        
        public void Update()
        {
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            foreach (var component in _components)
            {
                component.Update();
            }
        }
    }
}