using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events 
{
public class EventManagerSingleton : AdressableSingleton<EventManagerSingleton>
{
    public delegate void EventCallback<in T>(T data) where T : Event;
   private Dictionary<Type, List<Delegate>> m_events = new();
 
         public void Trigger<T>(T triggeredKey) where T : Event
         {
             if (!m_events.TryGetValue(typeof(T), out var listeners))
             {
                 return;
             }
 
             foreach (var listener in listeners.ToArray())
             {
                 listener.DynamicInvoke(triggeredKey);
             }
         }
 
         public void AddListener<T>(EventCallback<T> callback) where T : Event
         {
             if (m_events.TryGetValue(typeof(T), out var listeners))
             {
                 if (!listeners.Contains(callback))
                 {
                     listeners.Add(callback);
                 }
             }
             else
             {
                 listeners = new List<Delegate> { callback };
                 m_events.Add(typeof(T), listeners);
             }
         }
 
 
         public void RemoveEvent<T>() where T : Event
         {
             m_events.Remove(typeof(T));
         }
 
         public void AddEvent<T>() where T : Event
         {
             m_events.Add(typeof(T), new List<Delegate>());
         }
 
         public void RemoveListener<T>(EventCallback<T> callback) where T : Event
         {
             if (m_events.TryGetValue(typeof(T), out var listeners))
             {
                 listeners.Remove(callback);
             }
         }
}
    
}
