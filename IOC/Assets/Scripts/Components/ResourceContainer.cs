using UnityEngine;

public class ResourceContainer : IComponent
{
    public int associatedResource;
    public int amount;
    private ResourceContainerUpdatedEvent ResourceStructureUpdatedEvent => new (this);

    public ResourceContainer(int resource, int startAmount = 0)
    {
        associatedResource = resource;
        amount = startAmount;
    }

    public void Init()
    {
        
    }

    public void Update()
    {
        
    }

    public void Transfer(ResourceContainer other)
    {
        if(amount <= 0) return;

        other.amount += amount;
        amount = 0;

        EventManager.Trigger(other.ResourceStructureUpdatedEvent);
        EventManager.Trigger(ResourceStructureUpdatedEvent);
    }
    
    public void Transfer(ResourceContainer other,int value)
    {
        amount -= value;
        if(amount <= 0) return;

        other.amount += value;

        EventManager.Trigger(other.ResourceStructureUpdatedEvent);
        EventManager.Trigger(ResourceStructureUpdatedEvent);
    }

    public void IncreaseAmount(int value)
    {
        amount += value;
        EventManager.Trigger(ResourceStructureUpdatedEvent);
    }

    public void DecreaseAmount(int value)
    {
        amount -= value;
        if (amount < 0) amount = 0;
        EventManager.Trigger(ResourceStructureUpdatedEvent);
    }
}

public class ResourceContainerUpdatedEvent
{
    public ResourceContainer Container { get; private set; }

    public ResourceContainerUpdatedEvent(ResourceContainer container)
    {
        Container = container;
    }
}
