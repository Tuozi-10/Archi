using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Events;
using UnityEngine;
using Component = Components.Component;

public class RessourceComponent : Component
{
    public int Ressource
    {
        get => _ressource;
    }

    private int _ressource;
    private EventManagerSingleton _eventManagerSingleton;
    private int _startRessourceCount;

    private RessourceOwnerEnum ressourceOwner;
    //enum
    public void Init(Entity entity, RessourceComponentData data)
    {
        Init(entity);
        ressourceOwner = data.OwnerEnum;
        EventManagerSingleton.Get(SetEventManager);
    }

    public void IncreaseRessource(int amount)
    {
        _ressource += amount;
        
        _eventManagerSingleton.Trigger(new OnRessourceCountUpdatedEvent(amount, ressourceOwner));
    }

    private void SetEventManager(EventManagerSingleton eventManagerSingleton)
    {
        _eventManagerSingleton = eventManagerSingleton;
        IncreaseRessource(_startRessourceCount);
        Debug.Log("ressource set event");
        
    }

    public void DecreaseRessource(int amount)
    {
        _ressource -= amount;
        _eventManagerSingleton.Trigger(new OnRessourceCountUpdatedEvent(-amount, ressourceOwner));
    }
}