using DesignPatterns;

namespace Entities.Buildings
{
    public class Building : Composite
    {
        public BuildingSO Data;
        
        public Building(BuildingSO data)
        {
            Data = data;
        }
    }
}