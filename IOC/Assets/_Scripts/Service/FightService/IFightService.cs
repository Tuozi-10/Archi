using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public interface IFightService : ISwitchableService
    {
        Transform GetClosestTree(Vector3 pos);
        Transform GetClosestStone(Vector3 pos);
        List<GameObject> GetTrees();
        List<GameObject> GetStones();
        void InitializeGame();
    }
}
