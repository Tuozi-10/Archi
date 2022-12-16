using System;
using System.Collections;
using System.Collections.Generic;
using Attributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Service
{
    public class TickService : ITickeableService
{
    [SerializeField] private float tickRate = 10f;
    private float tickTimer;
    private static float tickTime;
    public static event Action tickEvent;

    [ServiceInit]
    void SetUp()
    {
        tickTime = 1 / tickRate;
        tickTimer = 0;
        Tick();
    }
    public static float getTickTime
    {
        get => tickTime;
    } 
    public async void Tick()
    {
        while (true)
        {
            if (tickTimer >= tickTime)
        {
            tickTimer -= tickTime;
            tickEvent?.Invoke();
     
        }
        else tickTimer += Time.deltaTime;
        await UniTask.DelayFrame(0);
        }
    }
  
}
}
