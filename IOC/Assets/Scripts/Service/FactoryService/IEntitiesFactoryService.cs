using UnityEngine;

namespace Service
{
    public interface IEntitiesFactoryService : IService
    {
        public void LoadData();
        public Unit CreateGatherUnit(Vector3 position,int soIndex);
        public Entity CreateEntity(Vector3 position,int soIndex);
    }
}

