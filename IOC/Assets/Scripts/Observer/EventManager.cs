using System;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Service;
using UnityEngine;

namespace Observer
{
    public interface IEventManager : IService
    {
    }

    public class EventManager : IEventManager
    {
        private static readonly Dictionary<Type, List<Delegate>> m_events = new();

        public delegate void EventCallback<in T>(T data);

        public static void AddListener<T>(EventCallback<T> callback)
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

        public static void RemoveListener<T>(EventCallback<T> callback)
        {
            if (m_events.TryGetValue(typeof(T), out var listeners))
            {
                if (listeners.Contains(callback))
                {
                    listeners.Remove(callback);
                }
            }
        }
        
        private void RemoveListeners(Action<DataEvent> func)
        {
            foreach (var listeners in m_events.Values)
            {
                if (listeners.Contains(func))
                {
                    listeners.Remove(func);
                }
            }
        }

        public static void Trigger<T>(T triggeredKey)
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
        // TODO TRANSFORMER EN SINGLETON
    }
}