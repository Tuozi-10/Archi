using System;
using DefaultNamespace;
using UnityEngine;

public class Entity : Composite
{
    public Vector3 currentTarget;
    public Vector3 currentPos;
    
    private entitySO data;
    
    public Action<int> OnGainRessource;
    public Action OnCreateTool;
    public Action<bool> OnReceiveInfo;
    public Action<Entity> OnIdle;

    public Entity(entitySO _data)
    {
        data = _data;
    }
    
    public void SetData(entitySO _data)
    {
       data = _data;
    }

    public Vector3 GetWoodTarget()
    {
        return data.ressourceTarget;
    }

}
