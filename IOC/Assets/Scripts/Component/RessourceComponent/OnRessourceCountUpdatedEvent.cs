using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class OnRessourceCountUpdatedEvent : Event
    {
        public int ValueUpdated;
        public RessourceOwnerEnum Owner;
        public OnRessourceCountUpdatedEvent(int valueUpdated, RessourceOwnerEnum owner )
        {
            ValueUpdated = valueUpdated;
            Owner = owner;
        }
    }
}
