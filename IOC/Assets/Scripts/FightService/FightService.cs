using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using Cysharp.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

public class FightService : IFightService
{
    private Vector3 spawnPos;
    private float CurrentTime = 3.0f;
    private GameObject minion;
    
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
        minion = Object.Instantiate(prefab);
        minion.transform.position = spawnPos;
        spawnPos.x += 1.5f;
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EnemySO>("Minion", SetData);
    }

    private void SetData(EnemySO data)
    {
        float HP = data.MaxHP;
        
        data.GetEntity().MaxHP = HP;
    }
    
    public void Switch()
    {
        
    }

    public void Enable()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Plane", ShowMap);
        MyUpdate();
    }
    
    protected async void MyUpdate()
    {
        while (true)
        {
            await UniTask.DelayFrame(0);
            OnTick(Time.deltaTime);
        }
    }

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
