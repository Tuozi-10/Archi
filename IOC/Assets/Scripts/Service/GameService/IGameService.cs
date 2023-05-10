using UnityEngine;

namespace Service
{
    public interface IGameService : IService
    {
        public Transform GetWorkerSpawnPosition();
        public Transform GetFreeWorkPlace();
    }
}