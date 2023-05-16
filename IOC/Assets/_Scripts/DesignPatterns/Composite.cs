using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
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

        public T GetComponent<T>()
        {
            foreach (var component in _components)
            {
                if (component is T myComponent)
                {
                    return myComponent;
                }
            }
            
            return default;
        }

        public void RemoveComponent(IComponent component)
        {
            if (_components.Contains(component))
            {
                _components.Remove(component);
            }
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