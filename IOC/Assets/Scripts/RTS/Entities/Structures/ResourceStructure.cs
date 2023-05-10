public class ResourceStructure : Structure
{
    private ResourceContainer container;

    public void AssignContainer(ResourceContainer c)
    {
        container = AddComponent(c);
    }
    
    protected override void Work()
    {
        if(container.amount <= 0) return;
        WorkingUnit.Container.amount++;
        container.amount--;
        print(container.amount);
    }
}
