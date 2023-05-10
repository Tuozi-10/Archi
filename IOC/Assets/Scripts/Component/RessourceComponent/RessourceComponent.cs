using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;
using Component = Components.Component;

public class RessourceComponent : Component
{
    public int Ressource
    {
        get => _ressource;
    }
    private int _ressource;


    public override void Init(Entity entity, params object[] args)
    {
        base.Init(entity);
     _ressource = ((RessourceComponentData)args[0]).StartRessourceCount;
    }

    public void IncreaseRessource(int amount)
    {
        _ressource += amount; 
    }

    public void DecreaseRessource(int amount)
    {
        _ressource -= amount;
    }

    
    
}
