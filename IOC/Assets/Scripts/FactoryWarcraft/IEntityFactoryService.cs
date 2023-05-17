using System.Collections;
using System.Collections.Generic;
using FactoryWarcraft;
using Service;
using UnityEngine;

public interface IEntityFactoryService : IService
{
    Entity CreateHarvester(Transform root, RessourceData dest);
    Entity CreateLumberjack(Transform root, RessourceData dest);
    Entity CreateBlackSmith(Transform root, RessourceData dest);
    void SetEntityToMesh(GameObject newMinion, Entity entity, RessourceData Dest);
}
