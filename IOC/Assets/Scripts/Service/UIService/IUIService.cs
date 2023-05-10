using DefaultNamespace;

namespace Service
{
    public interface IUIService : IService
    {
        public void UpdateResourcesUI(ResourcesSO so, int count);
    }
}

