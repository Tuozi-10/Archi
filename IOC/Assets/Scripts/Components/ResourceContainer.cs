public class ResourceContainer : IComponent
{
    public int associatedResource;
    public int amount;

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
}
