using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Component = Components.Component;

namespace Components
{
public class DropRessourceComponent : Component
{
    private RessourceComponent _ressourceComponentOwner;
    private RessourceComponent _ressourceComponent;

    public void Init(Entity entity, RessourceComponent ressourceOwner,  RessourceComponent ressourceComponent)
    {
        base.Init(entity);
        _ressourceComponentOwner = ressourceOwner;
        _ressourceComponent = ressourceComponent;
    }

    public void Drop()
    {
        _ressourceComponent.IncreaseRessource(_ressourceComponentOwner.Ressource);
        _ressourceComponentOwner.DecreaseRessource(_ressourceComponentOwner.Ressource);
    }
    
    
    
}
    
}
