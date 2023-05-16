using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Service;
using UnityEngine;

namespace Service
{
    public interface IAgentFactoryService : IEntitiesFactoryService
    {
        Entity CreateHarvester(Vector3 pos);
        Entity CreateLumberjack(Vector3 pos);

    }
}