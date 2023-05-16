using System;
using System.Collections;
using System.Collections.Generic;
using Dp.DesignPatterns;
using UnityEngine;

public class ResourceStocker : IComponent
{
    public void Update()
    {
        
    }

    public void Init()
    {
    }

    public void StockToHub(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Tree:
                
                break;
            case ResourceType.Stone:
                
                break;
        }
    }
}
