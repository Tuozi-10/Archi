using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class EventManagerService : IEventManagerService
    {
        private static readonly Dictionary<Type, List<Delegate>> m_events = new();

        public delegate void EventCallback<in T>(T data);

        #region Add

        public void AddListener<T>(EventCallback<T> callback)
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

        public void AddListeners<T>(params EventCallback<T>[] callbacks)
        {
            foreach (var cb in callbacks)
            {
                AddListener(cb);
            }
        }

        #endregion

        #region Remove

        public void RemoveListeners<T>()
        {
            if (m_events.TryGetValue(typeof(T), out var listeners))
            {
                listeners.Clear();
            }
            else
            {
                Debug.LogWarning($"Type of name {nameof(T)} was not found in dictionary!");
            }
        }

        public void RemoveListener<T>(EventCallback<T> callback)
        {
            if (m_events.TryGetValue(typeof(T), out var listeners))
            {
                if (listeners.Contains(callback))
                {
                    listeners.Remove(callback);
                }
                else Debug.LogWarning("Callback was not subscribed!");
            }
            else
            {
                Debug.LogWarning($"Type of name {nameof(T)} was not found in dictionary!");
            }
        }

        #endregion

        #region Trigger

        public void Trigger<T>(T triggeredKey)
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

        #endregion

        // TODO TRANSFORMER EN SERVICE
        // TODO TRANSFORMER EN SINGLETON
    }
}