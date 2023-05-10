using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Component = Components.Component;

namespace Components
{
public class DropRessourceComponent : Component
{
    private RessourceComponent _ressourceComponentOwner;
  

    public override void Init(Entity entity, params object[] args)
    {
        base.Init(entity, args);
        _ressourceComponentOwner = (RessourceComponent)args[0];
    }

    public void Drop(RessourceComponent ressourceComponent)
    {
        ressourceComponent.IncreaseRessource(_ressourceComponentOwner.Ressource);
        _ressourceComponentOwner.DecreaseRessource(_ressourceComponentOwner.Ressource);
    }
    
    
    
}
    
}
