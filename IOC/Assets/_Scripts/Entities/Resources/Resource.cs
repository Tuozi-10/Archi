using DesignPatterns;

namespace Entities.Resources
{
    public class Resource : Composite
    {
        public TypeResource TypeResource;
        public int Quantity;
        public ResourceSO Data;

        public Resource(int quantity, ResourceSO data)
        {
            Quantity = quantity;
            Data = data;
        }
    }
}