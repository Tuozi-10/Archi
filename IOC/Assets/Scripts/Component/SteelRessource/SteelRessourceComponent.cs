using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
public class SteelRessourceComponent : Component
{
    private RessourceComponent ressourceComponentOwner;
    private int steelAmount;
    
    public override void Init(Entity entity, params object[] args)
    {
        base.Init(entity, args);
        steelAmount =((SteelRessourceComponentData) args[0]).SteelAmount;
        ressourceComponentOwner =(RessourceComponent) args[1];
    }


    public void SteelRessource(RessourceComponent ressourceComponent)
    {
        var currentRessource = ressourceComponent.Ressource;
        ressourceComponent.DecreaseRessource(steelAmount);
        ressourceComponentOwner.IncreaseRessource(currentRessource-ressourceComponent.Ressource);
    }
    
}
    
}
