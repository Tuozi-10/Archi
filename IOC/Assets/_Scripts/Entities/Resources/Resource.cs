using DesignPatterns;

namespace Entities.Resources
{
    public class Resource : Composite
    {
        public ResourceSO Data;

        public Resource(ResourceSO data)
        {
            Data = data;
        }
    }
}