using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public interface IEntitiesFactoryService : IService
    {
        void Initialize();
        void CreateHarvester();
        void CreateLumberjack();
        void CreateTrees();
        void CreateStones();
        Transform GetClosestTree(Vector3 pos);
        Transform GetClosestStone(Vector3 pos);
        List<GameObject> GetTrees();
        List<GameObject> GetStones();
        void CreateEntityEvent(CreateEvent createEvent);
    }
}