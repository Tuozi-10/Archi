using Component;

public class Entity : Composite
{
    public EntitySO data;

    public Entity(EntitySO data)
    {
        this.data = data;
    }
}