using System;
using System.Collections.Generic;
using Attributes;

namespace Service
{
    public class EventService : IEventService
    {
        [DependsOnService] private IEntitiesFactoryService _entitiesFactoryService;
        
        private readonly Dictionary<Type, List<Delegate>> _events = new();

        public delegate void EventCallback<in T>(T data);

        public void Initialize()
        {
            AddListener<CreateEvent>(_entitiesFactoryService.CreateEntityEvent);
        }

        public void AddListener<T>(EventCallback<T> callback)
        {
            if (_events.TryGetValue(typeof(T), out var listeners))
            {
                if (!listeners.Contains(callback))
                {
                    listeners.Add(callback);
                }
            }
            else
            {
                listeners = new List<Delegate> { callback };
                _events.Add(typeof(T), listeners);
            }
        }

        public void RemoveListener<T>(EventCallback<T> callback)
        {
            if (_events.TryGetValue(typeof(T), out var listeners))
            {
                if (!listeners.Contains(callback))
                {
                    listeners.Remove(callback);
                }
            }
        }

        public void RemoveListeners<T>(EventCallback<T> callback)
        {
            
        }

        public void Trigger<T>(T triggeredKey)
        {
            if (!_events.TryGetValue(typeof(T), out var listeners))
            {
                
                return;
            }

            foreach (var listener in listeners.ToArray())
            {
                listener.DynamicInvoke(triggeredKey);
            }
        }
    }
}