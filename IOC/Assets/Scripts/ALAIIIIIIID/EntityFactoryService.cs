using System;
using Addressables;
using DefaultNamespace;
using UnityEngine;

public class EntityFactoryService : IEntityFactoryService
{
    private entitySO lumberJackSO;
    private entitySO MINECTAFTSO;

    public Entity CreateHarvester(Transform root, Vector3 dest)
    {
        Entity minecrafter = new Entity(MINECTAFTSO);
        minecrafter.AddComponent(new MoveToTargetComponent(root, null));
        
        return minecrafter;
    }

    public Entity CreateLumberjack(Transform root, Vector3 dest)
    {
        entitySO lumberjackSO = new entitySO();
        
        lumberjackSO.ressourceTarget = dest;

        Entity lumberjack = root.gameObject.AddComponent<Entity>();
        lumberjack.SetData(lumberjackSO);

        lumberjack.AddComponent(new MoveToTargetComponent(root ,lumberjack));
        lumberjack.AddComponent(new LumberjackBehaviour(lumberjack));
        return lumberjack;
    }
    
    public Entity CreateBlackSmith(Transform root, Vector3 dest)
    {
        entitySO lumberjackSO = new entitySO();
        
        lumberjackSO.ressourceTarget = dest;

        Entity laforge = root.gameObject.AddComponent<Entity>();
        laforge.SetData(lumberjackSO);

        laforge.AddComponent(new MoveToTargetComponent(root ,laforge));
        laforge.AddComponent(new BlackSmithBehaviour(laforge));
        return laforge;
    }
}
