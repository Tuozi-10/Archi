using System;

namespace Service
{
    public interface IGameService : IService
    {
        public event Action<int, int> OnResourceUpdated;
        public void UpdateResources(int index,int amount);
    }
}