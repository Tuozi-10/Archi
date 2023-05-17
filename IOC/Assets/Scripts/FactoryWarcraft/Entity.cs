using System;
using DefaultNamespace;
using FactoryWarcraft;
using UnityEngine;

public class Entity : Composite
{
    public Vector3 currentTarget;
    public Vector3 currentPos;
    
    public Action<Entity> OnNoRessource;
    
    public entitySO data;
    
    public Action<int> OnGainRessource;
    public Action OnCreateTool;
    public Action<bool> OnReceiveInfo;
    public Action<Entity> OnIdle;

    public Entity(entitySO _data)
    {
        data = _data;
    }

    public void SetTransform(Transform _tr)
    {
       
    }
    
    public void SetData(entitySO _data)
    {
       data = _data;
    }
    
    public void SetRessourceData(RessourceData ressourceData)
    {
        data.ressourceTarget = ressourceData;
    }

    public void RemoveRessource()
    {
        data.ressourceTarget.nbRemaining -= 10;
        if (data.ressourceTarget.nbRemaining <= 0)
        {
            data.ressourceTarget.nbRemaining = 0;
            if (data.ressourceTarget.go)
               data.ressourceTarget.go.SetActive(false);
            OnNoRessource?.Invoke(this);
        }
    }

    public Vector3 GetWoodTarget()
    {
        return data.ressourceTarget.pos;
    }

}
