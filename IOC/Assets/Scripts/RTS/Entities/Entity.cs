using UnityEngine;

public abstract class Entity : Composite
{
    public Vector3 Position => transform.position;
}
