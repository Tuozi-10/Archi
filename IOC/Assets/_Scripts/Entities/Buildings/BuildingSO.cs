using UnityEngine;

namespace Entities.Buildings
{
    [CreateAssetMenu(menuName = "BuildingSO", fileName = "new BuildingSO")]
    public class BuildingSO : ScriptableObject
    {
        Building GetBuilding()
        {
            return new Building(this);
        }
    }
}