using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

public class FightService : IFightService
{
    private Vector3 spawnPos;
    private float CurrentTime = 3.0f;
    
    [ServiceInit]
    public void Init()
    {
        spawnPos = new Vector3(0, 1, 0);
    }
    
    public void OnTick(float deltaTime)
    {
        CurrentTime -= deltaTime;
        if (CurrentTime <= 0)
        {
            CurrentTime = 3.0f;
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Minion", SpawnMinion);
        }
    }

    public void SpawnMinion(GameObject prefab)
    {
        GameObject minion = Object.Instantiate(prefab);
        minion.transform.position = spawnPos;
        spawnPos.x += 1.5f;
        
    }

    public void Switch()
    {
        
    }

    public void Enable()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Plane", 
            ShowMap);
        MyUpdate();
    }
    
    override 

    public void Disable()
    {
       
    }

    void ShowMap(GameObject obj)
    {
        GameObject map = Object.Instantiate(obj);
        map.SetActive(true);
        Release(obj);
    }
}
