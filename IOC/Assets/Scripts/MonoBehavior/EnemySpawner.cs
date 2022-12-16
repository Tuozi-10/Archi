using System;
using System.Collections;
using System.Collections.Generic;
using Service.FightSerice;
using Service.TickService;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    #region Service

    private IFightService m_fightService;

    public void Setup(IFightService fightService, ITickService tickService)
    {
        m_fightService = fightService;
        m_fightService.OnFightAction += OnUpdate;
    }

    #endregion

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int frameSpawnDelay = 100;
    private int timer;
    
    public void OnUpdate()
    {
        timer--;
        if (timer <= 0)
        {
            timer = frameSpawnDelay;
            Vector3 pos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
        }
    }

}
