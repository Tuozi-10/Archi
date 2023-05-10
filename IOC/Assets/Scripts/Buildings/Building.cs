using DesignPattern;

namespace Buildings
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