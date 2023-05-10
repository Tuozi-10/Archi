using System;

namespace Service
{
    public interface IGameService : IService
    {
        public event Action<int, int> OnResourceUpdated;
        public void IncreaseResources(int index, int amount);
        public void DecreaseResources(int index,int amount);
        public void UpdateResources(int index,int amount);
        public void SpawnUnit(int index);
    }
}