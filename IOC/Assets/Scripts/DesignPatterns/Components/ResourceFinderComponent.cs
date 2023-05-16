using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Dp.DesignPatterns;
using entities;
using UnityEngine;
using UnityEngine.AI;

public class ResourceFinderComponent : IComponent
{
    private ResourceType resource;
    private Entity entity;
    private int loadingDuration;

    public ResourceFinderComponent(Entity entity, ResourceType type)
    {
        resource = type;
        this.entity = entity;
        loadingDuration = type switch
        {
            ResourceType.Tree => SceneReferenceHolder.instance.woodLoadDuration,
            ResourceType.Stone => SceneReferenceHolder.instance.stoneLoadDuration,
            _ => 0
        };
    }

    public void Update() { }

    public Transform FindClosestResource()
    {
        return resource switch
        {
            ResourceType.Tree => SceneReferenceHolder.instance.wood,
            ResourceType.Stone => SceneReferenceHolder.instance.stone,
            _ => null
        };
    }

    private float timer;

    public bool LoadingResource()
    {
        if (timer >= loadingDuration)
        {
            switch (resource)
            {
                case ResourceType.Tree:
                    entity.GetWood();
                    break;
                case ResourceType.Stone:
                    entity.GetStone();
                    break;
            }

            timer = 0;
            return entity.isFull;
        }
        
        timer += Time.deltaTime;
        return false;
    }

    public void Init() { }
}

public enum ResourceType
{
    Tree,
    Stone
}