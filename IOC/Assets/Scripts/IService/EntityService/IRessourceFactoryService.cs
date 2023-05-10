using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Service;
using UnityEngine;

public interface IRessourceFactoryService : IEntitiesFactoryService
{
    Entity CreateRock(Vector3 pos);

    Entity CreateTree(Vector3 pos);
}
