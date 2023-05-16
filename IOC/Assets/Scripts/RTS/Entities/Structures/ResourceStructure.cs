using UnityEngine;

public class ResourceStructure : Structure
{
    private ResourceContainer container;
    [SerializeField] private bool deposit;

    public void AssignContainer(ResourceContainer c)
    {
        container = AddComponent(c);
        Debug.Log($"{gameObject.name} has container for resource {container.associatedResource}");
    }

    protected override void Work()
    {
        if (deposit)
        {
            WorkingUnit.Container.Transfer(container);
            return;
        }
        
        container.Transfer(WorkingUnit.Container,1);
    }

    public override bool CanWork()
    {
        if (container == null) return false;
        if (deposit) return true;
        return container.amount > 0;
    }
}
