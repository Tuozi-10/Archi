﻿using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class EventManager
    {
        private static readonly Dictionary<Type, List<Delegate>> m_events = new();

        public delegate void EventCallback<in T>(T data); 
        
        public static void AddListener<T>(EventCallback<T> callback) 
        {
            if (m_events.TryGetValue (typeof(T), out var listeners)) 
            {
                if (!listeners.Contains(callback))
                {
                    listeners.Add(callback);
                }
            } 
            else
            {
                listeners = new List<Delegate> {callback};
                m_events.Add(typeof(T), listeners);
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
        
        // TODO IMPLEMENTER REMOVE LISTENER
        // TODO TRANSFORMER EN SERVICE
        // TODO TRANSFORMER EN SINGLETON
        
    }
}