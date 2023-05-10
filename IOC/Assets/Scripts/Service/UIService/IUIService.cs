using DefaultNamespace;

namespace Service
{
    public interface IUIService : IService
    {
        public void UpdateResourcesUI(string resource, int count);
    }
}

