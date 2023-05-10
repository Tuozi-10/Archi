using UnityEngine;
using UnityEngine.AI;

public class Unit : Entity
{
    [field:SerializeField] public MeshRenderer Renderer { get; private set; }
    [field:SerializeField] public NavMeshAgent Agent { get; private set; }
}
