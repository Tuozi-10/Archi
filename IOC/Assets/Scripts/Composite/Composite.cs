using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Composite : MonoBehaviour
{
    private List<IComponent> components = new ();
    
    private void Update()
    {
        foreach (var component in components)
        {
            component.Update();
        }
    }
    
    public T AddComponent<T>(T component) where T : IComponent
    {
        components.Add(component);
        component.Init();
        return component;
    }

    public new T GetComponent<T>() where T : IComponent
    {
        return (T)components.FirstOrDefault(component => component is T);
    }

    public void RemoveComponent(IComponent component)
    {
        if (components.Contains(component)) components.Remove(component);
    }
    
}
