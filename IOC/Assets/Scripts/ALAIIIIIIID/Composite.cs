using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Composite : MonoBehaviour
{
    private List<IComponent> m_components = new List<IComponent>();

    private void Awake()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        if (m_components == null)
            m_components = new List<IComponent>();
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

    public T myGetComponent<T>()
    {
        foreach (var component in m_components)
        {
            if (component is T GoodComponent)
            {
                return GoodComponent;
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
        foreach (var component in m_components)
        {
            component.Update();
        }
    }
}