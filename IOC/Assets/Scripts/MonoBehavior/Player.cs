using System.Collections;
using System.Collections.Generic;
using Service.FightSerice;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IFightService m_fightService;
    
    public void Setup(IFightService fightService)
    {
        m_fightService = fightService;
    }

    public void InitSO(PlayerStatSO loadSO)
    {
        statSO = loadSO;
        OnStart();
    }
    
    private PlayerStatSO statSO;

    [SerializeField] private float currentLife;

    
    
    void OnStart()
    {
        currentLife = statSO.life;
    }
}
