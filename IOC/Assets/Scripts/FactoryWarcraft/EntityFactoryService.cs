using System;
using Addressables;
using DefaultNamespace;
using UnityEngine;

public class EntityFactoryService : IEntityFactoryService
{
    private entitySO m_lumberjack;
    private entitySO m_harvester;

    public Entity CreateHarvester(Transform root, Vector3 dest)
    {
        Entity harvester = new Entity(m_harvester);
        harvester.AddComponent(new MoveToTargetComponent(root, null));
        
        return harvester;
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

        Entity lumberjack = root.gameObject.AddComponent<Entity>();
        lumberjack.SetData(lumberjackSO);

        lumberjack.AddComponent(new MoveToTargetComponent(root ,lumberjack));
        lumberjack.AddComponent(new BlackSmithBehaviour(lumberjack));
        return lumberjack;
    }
}
