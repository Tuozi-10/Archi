using System.Collections.Generic;
using UnityEngine;

namespace Component
{
    public class Composite : MonoBehaviour
    {
        private List<IComponent> m_components = new List<IComponent>();

        private void Awake()
        {
            m_components = new List<IComponent>();
        }

        public void Init()
        {
            InitComponents();
        }

        private void Update()
        {
            UpdateComponents();
        }

        public void AddComponent(IComponent component)
        {
            m_components.Add(component);
            component.Init();
        }

        public T GetComponent<T>()
        {
            foreach (IComponent component in m_components)
            {
                if (component is T GoodComponent)
                {
                    return GoodComponent;
                }
            }
            
            return default;
        }

        private void InitComponents()
        {
            foreach (IComponent component in m_components)
            {
                component.Init();
            }
        }

        private void UpdateComponents()
        {
            foreach (IComponent component in m_components)
            {
                component.Update();
            }
        }
    }
}
