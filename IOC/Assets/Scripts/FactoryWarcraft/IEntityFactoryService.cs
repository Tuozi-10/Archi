using System.Collections;
using System.Collections.Generic;
using Service;
using UnityEngine;

public interface IEntityFactoryService : IService
{
    Entity CreateHarvester(Transform root, Vector3 dest);
    Entity CreateLumberjack(Transform root, Vector3 dest);
    Entity CreateBlackSmith(Transform root, Vector3 dest);
    void SetEntityToMesh(GameObject newMinion, Entity entity, Vector3 Dest);
}
