public class Forge : Structure
{
    private int expectedWood = 2;
    private int expectedRock = 2;
    private ResourceContainer woodContainer;
    private ResourceContainer rockContainer;

    public void AssignContainers(ResourceContainer w,int wa, ResourceContainer r,int ra)
    {
        woodContainer = w;
        rockContainer = r;
        expectedWood = wa;
        expectedRock = ra;
        
        EventManager.AddListener<ResourceContainerUpdatedEvent>(CheckIfStockCraftable);

        void CheckIfStockCraftable(ResourceContainerUpdatedEvent data)
        {
            if(!(woodContainer.amount < expectedWood || rockContainer.amount < expectedRock)) EventManager.Trigger(new OnStockCraftableEvent());
        }
    }
    
    protected override void Work()
    {
        WorkingUnit.Container.IncreaseAmount(1);
    }

    public override bool CanWork()
    {
        return !(woodContainer.amount < expectedWood || rockContainer.amount < expectedRock);
    }
}

public class OnStockCraftableEvent
{
    
}
