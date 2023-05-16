using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service.Event
{
public interface IEventService : IService
{
    /*
    delegate void EventCallback<in T>(T data) where T : Event;

    void Trigger<T>(T triggeredKey) where T : Event;
    void AddListener<T>(EventCallback<T> callback) where T : Event;
    void RemoveListener<T>(EventCallback<T> callback) where T : Event;

    public void RemoveEvent<T>() where T : Event;
    public void AddEvent<T>() where T : Event;
    */
}
    
}
