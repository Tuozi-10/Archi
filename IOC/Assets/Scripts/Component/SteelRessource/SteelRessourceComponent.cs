using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
public class SteelRessourceComponent : Component
{
    private RessourceComponent _ressourceComponentOwner;
    private RessourceComponent _ressourceComponent;
    private int steelAmount;
    
    public void Init(Entity entity, SteelRessourceComponentData data, RessourceComponent owner, RessourceComponent ressourceComponent)
    {
        Init(entity);
        steelAmount =(data).SteelAmount;
        _ressourceComponentOwner =owner;
        _ressourceComponent = ressourceComponent;
    }
 

    public void SteelRessource()
    {
        var currentRessource = _ressourceComponent.Ressource;
        _ressourceComponent.DecreaseRessource(steelAmount);
        _ressourceComponentOwner.IncreaseRessource(currentRessource-_ressourceComponent.Ressource);
    }
    
}
    
}
