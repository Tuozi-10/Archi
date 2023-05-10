using UnityEngine;

namespace Service
{
    public interface IGameService : IService
    {
        public Transform GetWorkerSpawnPosition();
        public Transform GetFreeWorkPlace();

        public void AddWood(int amount);
        public void AddStone(int amount);
    }
}