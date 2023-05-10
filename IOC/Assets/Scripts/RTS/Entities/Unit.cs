using UnityEngine;
using UnityEngine.AI;

public class Unit : Entity
{
    [field:SerializeField] public MeshRenderer Renderer { get; private set; }
    [field:SerializeField] public NavMeshAgent Agent { get; private set; }
    private ResourceContainer container;

    public ResourceContainer Container
    {
        get
        {
           if(container != null) return container;
           container = GetComponent<ResourceContainer>();
           return container;
        }
    }
}
